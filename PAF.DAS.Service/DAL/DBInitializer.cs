using Microsoft.AspNetCore.Identity;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.DAS.Service.DAL
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //This example just creates an Administrator role and one Admin users
        public async Task Initialize()
        {
            //create database schema if none exists
            _context.Database.EnsureCreated();

            if (!_context.Roles.Any(r => r.Name == "Administrator"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
                //Administrator user account
                await _userManager.CreateAsync(new ApplicationUser { UserName = "admin@application.com", Email = "admin@application.com" }, "12345Admin$");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("admin@application.com"), "Administrator");
                //AFOS Administrator user account
                await _userManager.CreateAsync(new ApplicationUser { UserName = "AFOSAdmin@application.com", Email = "AFOSAdmin@application.com" }, "12345Afos$");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("AFOSAdmin@application.com"), "Administrator");
                //NCOS Administrator user account
                await _userManager.CreateAsync(new ApplicationUser { UserName = "NCOSAdmin@application.com", Email = "NCOSAdmin@application.com" }, "12345Ncos$");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("NCOSAdmin@application.com"), "Administrator");
                //PAFTSTS Administrator user account
                await _userManager.CreateAsync(new ApplicationUser { UserName = "PAFTSTSAdmin@application.com", Email = "PAFTSTSAdmin@application.com" }, "12345Paftsts$");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("PAFTSTSAdmin@application.com"), "Administrator");
            }

            if (!_context.Roles.Any(r => r.Name == "Guest")) {
                await _roleManager.CreateAsync(new IdentityRole("Guest"));
                //Researcher user account
                await _userManager.CreateAsync(new ApplicationUser { UserName = "researcher@application.com", Email = "researcher@application.com" }, "12345Researcher$");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("researcher@application.com"), "Guest");
                //Student user account
                await _userManager.CreateAsync(new ApplicationUser { UserName = "student@application.com", Email = "student@application.com" }, "12345Student$");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("student@application.com"), "Guest");
            }
        }
    }
}
