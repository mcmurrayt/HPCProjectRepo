using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FindMyDoc.Server.Models;
using FindMyDoc.Server.Data;
using FindMyDoc.Shared;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Security.Claims;




namespace FindMyDoc.Server.Controllers;


    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(Roles = "Admin")]
    public class AdminController : Controller
        {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public AdminController(UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    [HttpGet]
    public async Task<List<UserAuthDto>> Get()
    {
        //var users = await _context.Users

        //            .Select(u => new UserAuthDto
        //            {
        //                Id = u.Id,
        //                userName = u.UserName,
        //                firstName = u.firstName,
        //                lastName = u.lastName,
        //                dob = u.dob,
        //                address = u.address,
        //                insuranceNum = u.insuranceNum,
        //                fips = u.fips,
        //                gender = u.gender,
        //                date = u.date,
        //                state = u.state,
        //                county = u.county,

        //            }).ToListAsync();


        try
        {


            var users = await
                (from u in _userManager.Users
                 select new UserAuthDto
                 {
                     Id = u.Id,
                     userName = u.UserName,
                     firstName = u.firstName,
                     lastName = u.lastName,
                     dob = u.dob,
                     address = u.address,
                     insuranceNum = u.insuranceNum,
                     fips = u.fips,
                     gender = u.gender,
                     date = u.date,
                     state = u.state,
                     county = u.county,
                     Roles = _userManager.GetRolesAsync(u).Result.ToList()
                 }).ToListAsync();

            return users;
        }
        catch (Exception ex)

        {
        Console.WriteLine(ex.ToString());

        }
        return new List<UserAuthDto>();
    }
}


