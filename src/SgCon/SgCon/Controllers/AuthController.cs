using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SgConAPI.Business.Contracts;
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
        private readonly IEmployeeBusinessService _employeeBusinessService;
        private readonly IResidentRepository _residentRepository;
        private readonly IResidentBusinessService _residentBusinessService;
        public AuthController(
            IOptions<JwtIssuerOptions> jwtOptions,
            JwtCurrentUserFactory jwtCurrentUserFactory,
            JwtFactory jwtFactory,
            IEmployeeRepository employeeRepository,
            IEmployeeBusinessService employeeBusinessService,
            IResidentRepository residentRepository,
            IResidentBusinessService residentBusinessService)
        {
            _jwtOptions = jwtOptions.Value;
            _jwtFactory = jwtFactory;

            _employeeRepository = employeeRepository;
            _employeeBusinessService = employeeBusinessService;

            _residentRepository = residentRepository;
            _residentBusinessService = residentBusinessService;
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

        [HttpGet]
        [Route("/api/resident/me/")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(typeof(string), 420)]
        public IActionResult GetMeResident([FromHeader] string authorization)
        {
            var resident = _jwtFactory.GetCurrentResidentUser();
            if (resident == null) { return BadRequest("Funcionário não encontrado"); }
            return Ok(resident);
        }

        [HttpPost]
        [Route("employee")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Token), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetTokenForEmployee([FromBody] ApplicationUser loginUser)
        {
            Employee user = _employeeBusinessService.GetEmployeeByEmailOrUsername(loginUser);

            if (user == null)
                return BadRequest("Usuário não encontrado");

            if (user.PassWord != loginUser.PassWord)
                return BadRequest("Senha inválida");

            if (!user.Active)
                return BadRequest("Usuário inativo, entre em contato com a administração");

            return this.GetClaimsIdentity(user).Result;
        }

        [HttpPost]
        [Route("resident")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Token), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetTokenForResident([FromBody] ApplicationUser loginUser)
        {
            Resident user = _residentBusinessService.GetResidentByEmailOrUsername(loginUser);

            if (user == null)
                return BadRequest("Usuário não encontrado");

            if (user.PassWord != loginUser.PassWord)
                return BadRequest("Senha inválida");

            if (!user.Active)
                return BadRequest("Usuário inativo, entre em contato com a administração");

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
            var role = "administrador";
            if (user.Profile.Role.Id == 3) { role = "resident"; }
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
