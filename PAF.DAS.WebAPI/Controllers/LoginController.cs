using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PAF.DAS.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/user")]
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _options;

        public LoginController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IOptions<JWTSettings> optionsAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _options = optionsAccessor.Value;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] LoginModel credentials)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(credentials.Email);
                    var roles = await _userManager.GetRolesAsync(user);
                    return new JsonResult(new
                    {
                        access_token = GetAccessToken(user, roles[0]),
                    });
                }
                return new UnauthorizedResult();
            }
            return new UnauthorizedResult();
        }

        [HttpGet("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { done = true });
        }

        private string GetAccessToken(IdentityUser user, string role)
        {
            var payload = new Dictionary<string, object>
            {
                { "id", user.Id },
                { "email", user.Email },
                { "isAdmin", role.ToLower() == "administrator" },
                { ClaimTypes.Role, role}
            };
            return GetToken(payload);
        }

        private string GetToken(Dictionary<string, object> payload)
        {
            var secret = _options.SecretKey;

            payload.Add("iss", _options.Issuer);
            payload.Add("aud", _options.Audience);
            payload.Add("nbf", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("iat", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("exp", ConvertToUnixTimestamp(DateTime.Now.AddDays(7)));
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, secret);
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}