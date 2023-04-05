using FindMyDoc.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> OnGet()
        {
            // Get the current user's ID
            var userId = _signInManager.UserManager.GetUserId(User);

            // Retrieve the user's email and phone number
            var user = await _userManager.FindByIdAsync(userId);
            var username = user.UserName;
            var firstname = user.firstName;
            var lastname = user.lastName;
            var dob = user.dob;
            var region = user.county;
            var insurance = user.insuranceNum;

            var model = new ApplicationUser
            {
                UserName = username,
                firstName = firstname,
                lastName = lastname,
                dob = dob,
                county = region,
                insuranceNum = insurance
            };

            return new JsonResult(model);
        }
    }
}