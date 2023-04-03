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

        [HttpGet]
        [Route("api/get-providers/{Fips}")]
        public static Provider GetProviderByFips(string Fips)
        {
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://www.healthit.gov/data/open-api?source=SKA_State_County_Data_2011-2013.csv") };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string newURL = "https://www.healthit.gov/data/open-api?source=SKA_State_County_Data_2011-2013.csv" + "&fips=" + Fips + "&period=2013";
            HttpResponseMessage r = httpClient.GetAsync(newURL).Result;

            string rContent = r.Content.ReadAsStringAsync().Result;
            //the default json object being printed
            Console.WriteLine(rContent);

            Provider p = JsonConvert.DeserializeObject<Provider>(rContent);
            return p;
        }
    }
}
