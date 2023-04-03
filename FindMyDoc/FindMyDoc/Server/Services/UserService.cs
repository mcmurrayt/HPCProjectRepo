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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<bool> UpdateUserFips(ApplicationUser user)
        {
            string CountyNormalized = user.county.ToLower();

            FipsCounty fipsC = (from c in _context.FipsCounties where c.CountyName == CountyNormalized select c).FirstOrDefault();

            string fips = (from s in _context.FipsStates
                           join c in _context.FipsCounties on s.Id equals c.FipsStateId
                           where s.StateName == user.state
                           where c.CountyName == fipsC.CountyName
                           select c.CountyFIPSCode).FirstOrDefaultAsync().ToString();
            if (String.IsNullOrEmpty(fips))
            {
                string newFips = (from s in _context.FipsStates
                                  join c in _context.FipsCounties on s.Id equals c.FipsStateId
                                  where s.StateName == user.state
                                  where c.CountyName == user.state
                                  select c.CountyFIPSCode).FirstOrDefaultAsync().ToString();
            }
            return true;
        }
    }
}
