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

        public UserAccountController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager
          )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //Get all Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userManager.Users);
        }

        [HttpPut("{id}/reset")]
        public async Task<IActionResult> Reset(string id, [FromBody] PasswordResetModel credentials)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByIdAsync(credentials.Id);
                var result = await _userManager.ChangePasswordAsync(currentUser, credentials.OldPassword, credentials.NewPassword);
                if (result.Succeeded)
                {
                    return Ok(new { done = true });
                }
            }
            return BadRequest();
        }
    }
}