using FindMyDoc.Server.Data;
using FindMyDoc.Server.Models;
using FindMyDoc.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FindMyDoc.Server.Services

{
    public class UserService
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context) //UserManager<ApplicationUser> userManager
        {
            //_userManager = userManager;
            _context = context;
        }

        public async Task<string> UpdateUserFips(string state, string county)
        {
            try
            {
                string CountyNormalized = county.ToLower();
                string StateNormalized = state.ToLower();

                FipsCounty fipsC =  (from c in _context.FipsCounties where c.CountyName.ToLower() == CountyNormalized select c).FirstOrDefault();

                string fips = (from s in _context.FipsStates
                               join c in _context.FipsCounties on s.Id equals c.FipsStateId
                               where s.StateName.ToLower() == StateNormalized
                               where c.CountyName == fipsC.CountyName
                               select c.CountyFIPSCode).FirstOrDefault().ToString();
                if (String.IsNullOrEmpty(fips))
                {
                    fips = (from s in _context.FipsStates
                                      join c in _context.FipsCounties on s.Id equals c.FipsStateId
                                      where s.StateName.ToLower() == StateNormalized
                                      where c.CountyName.ToLower() == StateNormalized
                                      select c.CountyFIPSCode).FirstOrDefaultAsync().ToString();
                }
                return fips;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "error";
            }
        }
    }
}
