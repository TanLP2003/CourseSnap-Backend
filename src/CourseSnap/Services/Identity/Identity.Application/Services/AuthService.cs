using AutoMapper;
using Identity.Application.Extensions;
using Identity.Application.Models;
using Identity.Domain.Entities;
using Identity.Domain.Exceptions;
using JwtSetup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AuthService> _logger;
        private readonly JwtKeyOptions _jwtKeyOptions;

        public AuthService(IMapper mapper, UserManager<User> userManager, ILogger<AuthService> logger, JwtKeyOptions jwtKeyOptions)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _jwtKeyOptions = jwtKeyOptions;
        }

        public async Task<Token> Login(UserLoginModel loginModel)
        {
            var result = await ValidateUser(loginModel.Email, loginModel.Password);
            if (!result) throw new BadRequestException("Login Failed");

            var token = await GenerateToken(loginModel.Email);
            return token;
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterModel model)
        {
            var user = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                _logger.LogInformation("Sign up successful");
                return result;
            }
            _logger.LogInformation("Sign up failed");
            return result;
        }

        public async Task UpdateUser(string userEmail, UserUpdateModel updateModel)
        {
            var result = await ValidateUser(userEmail, updateModel.OldPassword);
            if (!result) throw new BadRequestException("Invalid Update Request");

            var user = await _userManager.FindByEmailAsync(userEmail);
            user.FirstName = updateModel.NewFirstName;
            user.LastName = updateModel.NewLastName;
            var updateResult =  await _userManager.ChangePasswordAsync(user, updateModel.OldPassword, updateModel.NewPassword);
            if (!updateResult.Succeeded) throw new BadRequestException("Update Failed");
        }

        public async Task<Token> GenerateToken(string userEmail)
        {
            var rsa = await GetRsaExtensions.UseKeyFromFile(_jwtKeyOptions.PrivateKeyFilePath);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var signingCredential = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, userEmail) };
            var jwtSecurityOptions = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: signingCredential,
                    expires: DateTime.Now.AddMinutes(10)
                );

            var accessToken = jwtTokenHandler.WriteToken(jwtSecurityOptions);
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            return new Token
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }

        public async Task<string> GetUserEmailFromToken(HttpContext context)
        {
            var authString = context.Request.Headers.Authorization.ToString();
            var token = authString.Split(" ")[1];

            var principal = await GetPrincipalFromToken(token);
            var userEmail = principal.FindFirst(ClaimTypes.Email).Value;
            return userEmail;
        }

        private async Task<ClaimsPrincipal> GetPrincipalFromToken(string token)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var rsa = await GetRsaExtensions.UseKeyFromFile(_jwtKeyOptions.PublicKeyFilePath);

            var tokenValidationParam = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = new RsaSecurityKey(rsa)
            };

            var principal = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParam, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.RsaSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        private async Task<bool> ValidateUser(string userEmail, string password)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            return !(user == null || !await _userManager.CheckPasswordAsync(user, password));
        }
    }
}