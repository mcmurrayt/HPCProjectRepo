using FindMyDoc.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FindMyDoc.Server.Controllers
{
    [Authorize]
    public class OutputController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public OutputController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("output/on-get")]
        public async Task<IActionResult> OnGet()
        {
            // Get the current user's ID
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(id);

            // Retrieve the user's email and phone number
            

            var model = new ApplicationUser
            {
                UserName = user.UserName,
                firstName = user.firstName,
                lastName = user.lastName,
                dob = user.dob,
                address = user.address,
                county = user.county,
                state = user.state,
                insuranceNum = user.insuranceNum
              
            };

            return new JsonResult(model);
        }
    }
}