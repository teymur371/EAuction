using EAuction.Dtos.Registration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EAuction.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var errors = new List<string>();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = dto.Email,
                    Email = dto.Email
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok("Registration Completed!");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    errors.Add(error.Description);
                }
            }
            for (int i = 0; i < errors.Count; i++)
            {
                return BadRequest(errors[i]);
            }
            return null;
        }
    }
}
