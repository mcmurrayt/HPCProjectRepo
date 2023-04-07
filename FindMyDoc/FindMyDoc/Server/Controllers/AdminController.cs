using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FindMyDoc.Server.Models;
using FindMyDoc.Server.Data;
using FindMyDoc.Shared;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Security.Claims;
using FindMyDoc.Server.Services;

namespace FindMyDoc.Server.Controllers;

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
    [Route("api/get-user-by-id/{userId}")]
    public async Task<ActionResult<UserAuthDto>> GetUserById(string userId)
    {
        try
        {
            var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            return Ok(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return NotFound();
    }

    [HttpGet]
    [Route("api/admin-get/")]
    public async Task<ActionResult<List<UserAuthDto>>> Get()
    {
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

            return Ok(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return new List<UserAuthDto>();
    }
    [HttpDelete]
    [Route("api/delete-user/{userId}")]
    public async Task DeleteUser(string userId)
    {
        try
        {
            var u = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            _context.Users.Remove(u);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    [HttpPut]
    [Route("api/update-user")]
    public async Task UpdateUser([FromBody] UserAuthDto user)
    {
        UserService userService = new UserService(_context);
        try
        {
            var u = _context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            u.county = user.county;
            u.state = user.state;
            u.fips = await userService.UpdateUserFips(u.state, u.county);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}