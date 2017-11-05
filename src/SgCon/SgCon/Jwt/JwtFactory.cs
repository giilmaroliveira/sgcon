using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SgConAPI.Models;
using SgConAPI.Options;
using System;
using SgConAPI.EntityFramework;
using SgConAPI.Models.Contracts;
using SgConAPI.Repository.Contracts;

namespace SgConAPI.Jwt
{
    public class JwtFactory : IDisposable
    {
        private readonly SgConContext _context;
        private readonly JwtCurrentUserFactory _jwCurrentUsertFactory;
        private readonly IEmployeeRepository _employeeRepository;
        public JwtFactory(
            JwtCurrentUserFactory jwtCurrentUserFactory,
            SgConContext context,
            IEmployeeRepository employeeRepository)
        {
            _jwCurrentUsertFactory = jwtCurrentUserFactory;
            _context = context;
            _employeeRepository = employeeRepository;
        }

        public Employee GetCurrentEmployeeUser()
        {
            ApplicationUser appUser = _jwCurrentUsertFactory.getCurrentLoggedUser();
            Employee employee = JwtFactory.GetCurrentEmployeeUser(_employeeRepository, appUser);

            return employee;
        }

        internal static Employee GetCurrentEmployeeUser(IEmployeeRepository repository, ApplicationUser appUser)
        {
            Employee employee = null;
            if (appUser != null && !(string.IsNullOrEmpty(appUser.UserName)) && appUser.ClassType.Equals("SgConAPI.Models.Employee"))
            {
                employee = repository.GetEmployeeByUserName(appUser.UserName);
            }
            return employee;
        }


        //TODO
        //Inserir métodos para busca de moradores, iguais ao employee
        public Profile GetCurrentEmployeeProfile()
        {
            Employee employee = GetCurrentEmployeeUser();
            if (employee != null)
                return employee.Profile;

            //TODO
            //Morador

            return null;
        }

        public IAuthenticable GetCurrentUser()
        {
            Employee employee = GetCurrentEmployeeUser();
            if (employee != null)
                return employee;

            //TODO
            //Morador

            return null;
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
            Employee funcionario = null;
            if (user is Employee)
            {
                funcionario = (Employee)user;
            }
        }

        public async void JwtTokenLogSuccess(IAuthenticable user, string message)
        {
            var usr = JsonConvert.SerializeObject(user);
            Employee employee = null;
            if (user is Employee)
            {
                employee = (Employee)user;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
