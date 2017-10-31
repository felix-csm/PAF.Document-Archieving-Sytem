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
                await _userManager.CreateAsync(new ApplicationUser { UserName = "admin@application.com", Email = "admin@application.com" }, "12345Admin$");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("admin@application.com"), "Administrator");
            }

            if (!_context.Roles.Any(r => r.Name == "Guest")) {
                await _roleManager.CreateAsync(new IdentityRole("Guest"));
                await _userManager.CreateAsync(new ApplicationUser { UserName = "guest@application.com", Email = "guest@application.com" }, "12345Guest$");
                await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("guest@application.com"), "Guest");
            }
        }
    }
}
