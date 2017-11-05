using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SgConAPI.Models;
using SgConAPI.Options;
using System;
using SgConAPI.EntityFramework;
using SgConAPI.Models.Contracts;


namespace SgConAPI.Jwt
{
    public class JwtFactory : IDisposable
    {
        private readonly SgConContext _context;
        private readonly JwtCurrentUserFactory _jwCurrentUsertFactory;
        public JwtFactory(
            JwtCurrentUserFactory jwtCurrentUserFactory,
            SgConContext context)
        {
            _jwCurrentUsertFactory = jwtCurrentUserFactory;
            _context = context;
        }

        public void InitJwt(IApplicationBuilder app, IConfigurationRoot configuration, SymmetricSecurityKey signingKey)
        {
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = false,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            //https://github.com/aspnet/Security/issues/1310
            app.UseJwtBearerAuthentication(
                new JwtBearerOptions
                {
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true,
                    TokenValidationParameters = tokenValidationParameters
                }
            );
        }

        public async void JwtTokenLogFailed(IAuthenticable user, string message)
        {
            var usr = JsonConvert.SerializeObject(user);
            Funcionario funcionario = null;
            if (user is Funcionario)
            {
                funcionario = (Funcionario)user;
            }
        }

        public async void JwtTokenLogSuccess(IAuthenticable user, string message)
        {
            var usr = JsonConvert.SerializeObject(user);
            Funcionario funcionario = null;
            if (user is Funcionario)
            {
                funcionario = (Funcionario)user;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
