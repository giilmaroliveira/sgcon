using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SgConAPI.Jwt;
using SgConAPI.Models;
using SgConAPI.Models.Contracts;
using SgConAPI.Options;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SgConAPI.Controllers
{
    [Route("api/token")]
    public class AuthController : Controller
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly JwtFactory _jwtFactory;
        private readonly IEmployeeRepository _employeeRepository;
        public AuthController(
            IOptions<JwtIssuerOptions> jwtOptions, 
            JwtCurrentUserFactory jwtCurrentUserFactory,
            JwtFactory jwtFactory,
            IEmployeeRepository employeeRepository)
        {
            _jwtOptions = jwtOptions.Value;
            _jwtFactory = jwtFactory;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("/api/employee/me/")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(typeof(string), 420)]
        public IActionResult GetMeEmplooye([FromHeader] string authorization)
        {
            var employee = _jwtFactory.GetCurrentEmployeeUser();
            if (employee == null) { return BadRequest("Funcionário não encontrado"); }
            return Ok(employee);
        }

        [HttpPost]
        [Route("employee")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Token), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetTokenForEmployee([FromBody] ApplicationUser loginUser)
        {
            Employee user = (from e in _employeeRepository.Entities.Include(e => e.Profile).Include(e => e.Profile.Role)
                             where ((e.UserName == loginUser.UserName || e.Email == loginUser.UserName))
                             select e).FirstOrDefault();

            if (user == null)
                return BadRequest("Usuário e/ou senha inválida");

            return this.GetClaimsIdentity(user).Result;
        }

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }

        private async Task<OkObjectResult> GetClaimsIdentity(IAuthenticable user)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"),
                              new[]
                              {
                                    new Claim("RoleId", user.Profile.Role.Id.ToString())
                              });
            var role = "customer";
            if (user.Profile.Role.Id == 3) { role = "administrator"; }
            if (user.Profile.Role.Id == 2) { role = "employee"; }
            var claims = new[]
            {
                new Claim("UserName", user.UserName),
                new Claim("UserType", user.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("RoleId"),
                new Claim("roles", role)
            };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Serialize and return the response
            var response = new Token
            {
                access_token = encodedJwt,
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);

            _jwtFactory.JwtTokenLogSuccess(user, json);

            return new OkObjectResult(json);
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
