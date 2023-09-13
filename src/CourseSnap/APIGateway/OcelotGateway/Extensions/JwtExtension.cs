using JwtSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace OcelotGateway.Extensions
{
    public static class JwtExtension
    {
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtKeyOption = new JwtKeyOptions();
            configuration.Bind(nameof(JwtKeyOptions), jwtKeyOption);
            services.AddSingleton(jwtKeyOption);

            services.CreateRsaKey(jwtKeyOption);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer("Bearer", options =>
                {
                    var rsa = RSA.Create();
                    var publicKey = File.ReadAllText(jwtKeyOption.PublicKeyFilePath);
                    rsa.FromXmlString(publicKey);

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("IS_TOKEN_EXPIRED", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new RsaSecurityKey(rsa)
                    };

                });
        }

        private static void CreateRsaKey(this IServiceCollection services, JwtKeyOptions jwtOptions)
        {
            string privateKeyFolder = Path.GetDirectoryName(jwtOptions.PrivateKeyFilePath);
            if (!Directory.Exists(privateKeyFolder)) Directory.CreateDirectory(privateKeyFolder);

            var rsa = RSA.Create();
            string privateKey = rsa.ToXmlString(true);
            string publicKey = rsa.ToXmlString(false);

            using var privateFile = File.Create(jwtOptions.PrivateKeyFilePath);
            using var publicFile = File.Create(jwtOptions.PublicKeyFilePath);

            privateFile.Write(Encoding.ASCII.GetBytes(privateKey));
            publicFile.Write(Encoding.ASCII.GetBytes(publicKey));
        }
    }
}
