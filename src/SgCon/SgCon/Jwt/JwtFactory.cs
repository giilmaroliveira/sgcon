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
        private readonly IResidentRepository _residentRepository;
        public JwtFactory(
            JwtCurrentUserFactory jwtCurrentUserFactory,
            SgConContext context,
            IEmployeeRepository employeeRepository,
            IResidentRepository residentRepository)
        {
            _jwCurrentUsertFactory = jwtCurrentUserFactory;
            _context = context;
            _employeeRepository = employeeRepository;
            _residentRepository = residentRepository;
        }

        public Employee GetCurrentEmployeeUser()
        {
            ApplicationUser appUser = _jwCurrentUsertFactory.getCurrentLoggedUser();
            Employee employee = JwtFactory.GetCurrentEmployeeUser(_employeeRepository, appUser);

            return employee;
        }

        public Resident GetCurrentResidentUser()
        {
            ApplicationUser appUser = _jwCurrentUsertFactory.getCurrentLoggedUser();
            Resident resident = JwtFactory.GetCurrentResidentUser(_residentRepository, appUser);

            return resident;
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

        internal static Resident GetCurrentResidentUser(IResidentRepository repository, ApplicationUser appUser)
        {
            Resident resident = null;
            if (appUser != null && !(string.IsNullOrEmpty(appUser.UserName)) && appUser.ClassType.Equals("SgConAPI.Models.Resident"))
            {
                resident = repository.GetResidentByUserName(appUser.UserName);
            }
            return resident;
        }

        public Profile GetCurrentUserProfile()
        {
            Employee employee = GetCurrentEmployeeUser();
            if (employee != null)
                return employee.Profile;

            Resident resident = GetCurrentResidentUser();
            if (resident != null)
                return resident.Profile;

            return null;
        }

        public IAuthenticable GetCurrentUser()
        {
            Employee employee = GetCurrentEmployeeUser();
            if (employee != null)
                return employee;

            Resident resident = GetCurrentResidentUser();
            if (resident != null)
                return resident;

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
            Employee employee = null;
            if (user is Employee)
            {
                employee = (Employee)user;
            };
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
