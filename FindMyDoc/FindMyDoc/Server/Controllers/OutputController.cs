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
            var username = user.UserName;
            var firstname = user.firstName;
            var lastname = user.lastName;
            var dob = user.dob;
            var address = user.address;
            var region = user.county;
            var state = user.state;
            var insurance = user.insuranceNum;

            var model = new ApplicationUser
            {
                UserName = username,
                firstName = firstname,
                lastName = lastname,
                dob = dob,
                address = address,
                county = region,
                state = state,
                insuranceNum = insurance
            };

            return new JsonResult(model);
        }
    }
}