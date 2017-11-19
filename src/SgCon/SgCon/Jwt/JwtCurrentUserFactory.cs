using Microsoft.AspNetCore.Http;
using SgConAPI.Models;
using System;
using System.Linq;

namespace SgConAPI.Jwt
{
    public class JwtCurrentUserFactory : IDisposable
    {
        private readonly IHttpContextAccessor _httpContext;

        public JwtCurrentUserFactory(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ApplicationUser getCurrentLoggedUser()
        {
            if (_httpContext.HttpContext == null || _httpContext.HttpContext.User == null) { return null; }
            var user = _httpContext.HttpContext.User;
            if (!user.Claims.Any()) { return null; }
            var userName = user.Claims.Where(c => c.Type == "UserName").First().Value;
            var userType = user.Claims.Where(c => c.Type == "UserType").First().Value;
            ApplicationUser loggedUser = null;
            loggedUser = new ApplicationUser() { UserName = userName, ClassType = userType };

            return loggedUser;
        }
    }
}
