using Microsoft.AspNetCore.Mvc;
using PAF.DAS.Service.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using JWT.Algorithms;
using JWT.Serializers;
using JWT;
using System.Threading.Tasks;
using System.Linq;

namespace PAF.DAS.WebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/users")]
    public class UserAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _options;

        public UserAccountController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IOptions<JWTSettings> optionsAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _options = optionsAccessor.Value;
        }
        //Get all Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userManager.Users);
        }

        [HttpPut("reset")]
        public async Task<IActionResult> Reset([FromBody] PasswordResetModel credentials)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                var result = await _userManager.ChangePasswordAsync(currentUser, credentials.CurrentPassword, credentials.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(currentUser, isPersistent: false);
                    var user = await _userManager.FindByEmailAsync(credentials.Email);
                    var roles = await _userManager.GetRolesAsync(user);
                    return new JsonResult(new CurrentUserModel
                    {
                        Email = credentials.Email,
                        Token = GetAccessToken(user, roles[0]),
                        Roles = roles[0]
                    });
                }
                return Errors(result);
            }
            return Error("Unexpected error");
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
        private JsonResult Errors(IdentityResult result)
        {
            var items = result.Errors
                .Select(x => x.Description)
                .ToArray();
            return new JsonResult(items) { StatusCode = 400 };
        }

        private JsonResult Error(string message)
        {
            return new JsonResult(message) { StatusCode = 400 };
        }
    }
}