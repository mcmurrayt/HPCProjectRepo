using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FindMyDoc.Server.Data;
using FindMyDoc.Server.Models;
using FindMyDoc.Shared;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace FindMyDoc.Server.Controllers
{
    public class ProviderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProviderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("api/get-provider")]
        public async Task<ActionResult<Provider>> GetProvider()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                try
                {
                    var p = _context.Providers.Where(x => x.fips != "" && Convert.ToInt32(x.fips) == Convert.ToInt32(user.fips)).FirstOrDefault();
                    return Ok(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else { return NotFound(); }
        }

        [HttpGet]
        [Route("api/create-provider")]
        public async Task<ActionResult<bool>> GetProviderByFips()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    string fips = user.fips;

                    var newURL = $"https://www.healthit.gov/data/open-api?source=SKA_State_County_Data_2011-2013.csv";
                    Console.WriteLine(newURL);
                    List<Provider> providers = await httpClient.GetFromJsonAsync<List<Provider>>(newURL);
                    var provider = providers.Where(x => x.fips != "" && Convert.ToInt32(x.fips) == Convert.ToInt32(fips)).LastOrDefault();

                    _context.Providers.Add(provider);
                    await _context.SaveChangesAsync();

                    return Ok(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest();
                }
            }
            else { return NotFound(); }
        }
    }
}