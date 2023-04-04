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

        public ProviderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /*[HttpGet]
        [Route("api/get-providers")]
        public async Task<ActionResult<List<Provider>>> GetProviders()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
                return NotFound();
            var list = await _context.Providers.Where(x => x.fips == user.fips).ToListAsync();
            return list;
        }*/

        [HttpGet]
        [Route("api/fetch-provider")]
        public async Task<ActionResult<Provider>> GetProvider()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user != null)
            {
                try
                {
                    var p = _context.Providers.Where(x => x.fips == user.fips).FirstOrDefault();
                    return Ok(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("api/get-provider")]
        public async Task<Provider> GetProviderByFips(string fips)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                var newURL = $"https://www.healthit.gov/data/open-api?source=SKA_State_County_Data_2011-2013.csv";
                Console.WriteLine(newURL);
                List<Provider> providers = await httpClient.GetFromJsonAsync<List<Provider>>(newURL);

                var f = (from p in providers
                               where p.fips == fips
                               select p).LastOrDefault();

                Console.WriteLine(f);
                Console.WriteLine("Created Provider");
                return f;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new Provider();
        }

        [HttpPost]
        [Route("api/add-provider")]
        public void AddProvider([FromBody] Provider provider)
        {
            try
            {
                _context.Providers.Add(provider);
                Console.WriteLine("Added Provider to db");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpGet]
        [Route("{num}")]
        public int PrintNumber(int num)
        {
            //HttpClient httpClient = new HttpClient();
            //var url = "https://localhost:7126/";
            return num;
        }
    }
}
