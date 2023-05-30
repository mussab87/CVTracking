using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace App.Infrastructure.Mail.Initializer { }

public class DbInitializer : IDbInitializer
{
    private readonly AppDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DbInitializer(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _db = db;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public void Initialize()
    {
        if (_roleManager.FindByNameAsync(Roles.SuperAdmin).Result == null)
        {
            _roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();
        }
        else { return; }

        ApplicationUser adminUser = new ApplicationUser()
        {
            UserName = "admin",
            Email = "admin1@gmail.com",
            EmailConfirmed = true,
            PhoneNumber = "111111111111",
            FirstName = "admin",
            LastName = "test"
        };

        _userManager.CreateAsync(adminUser, "Admin@123456").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(adminUser, Roles.SuperAdmin).GetAwaiter().GetResult();

        var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
                new Claim(JwtClaimTypes.Name,adminUser.FirstName+" "+ adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,Roles.Admin),
            }).Result;

        ApplicationUser customerUser = new ApplicationUser()
        {
            UserName = "user",
            Email = "user@gmail.com",
            EmailConfirmed = true,
            PhoneNumber = "111111111111",
            FirstName = "user",
            LastName = "test"
        };

        _userManager.CreateAsync(customerUser, "Admin@123456").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(customerUser, Roles.Admin).GetAwaiter().GetResult();
    }
}

