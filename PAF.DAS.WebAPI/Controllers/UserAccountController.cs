using Microsoft.AspNetCore.Mvc;
using PAF.DAS.Service.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

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
    }
}