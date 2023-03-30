using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FindMyDoc.Server.Data;
using FindMyDoc.Server.Models;
using FindMyDoc.Shared;

namespace FindMyDoc.Server.Controllers
{
    public class ProviderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProviderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("api/get-providers")]

        public async Task<ActionResult<List<Provider>>> GetProviders()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await _context.Providers.Where(x => x.fips == user.fips).ToListAsync();



        }
    }
}
