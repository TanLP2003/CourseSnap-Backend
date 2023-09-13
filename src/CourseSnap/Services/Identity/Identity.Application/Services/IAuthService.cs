using Identity.Application.Models;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Services
{
    public interface IAuthService
    {
        Task<Token> Login(UserLoginModel loginModel);
        Task<IdentityResult> RegisterUser(UserRegisterModel model);
        Task UpdateUser(string userEmail, UserUpdateModel model);
        Task<Token> GenerateToken(string userEmail);
        Task<string> GetUserEmailFromToken(HttpContext context);
        //Task<Token> RefreshToken();
    }
}
