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

    public void InitializeAsync()
    {
        if (_roleManager.FindByNameAsync(Roles.SuperAdmin).Result == null)
        {
            _roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Roles.ForeignAgent)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Roles.LocalAgent)).GetAwaiter().GetResult();
        }
        else { return; }

        ApplicationUser adminUser = new ApplicationUser()
        {
            UserName = "admin",
            Email = "admin1@gmail.com",
            EmailConfirmed = true,
            PhoneNumber = "111111111111",
            FirstName = "admin",
            LastName = "test",
            UserStatus = true,
            CreatedBy = "System Super Admin",
            CreatedDate = DateTime.Now
        };

        _userManager.CreateAsync(adminUser, "Admin@123456").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(adminUser, Roles.SuperAdmin).GetAwaiter().GetResult();

        var userNew =  _userManager.FindByIdAsync(adminUser.Id).Result;
        var allPermissions = GetAllClaimsPermissions.GetAllControllerActionsUpdated();
        var tmp = _userManager.AddClaimsAsync(userNew, allPermissions).Result;

        ApplicationUser customerUser = new ApplicationUser()
        {
            UserName = "user",
            Email = "user@gmail.com",
            EmailConfirmed = true,
            PhoneNumber = "111111111111",
            FirstName = "user",
            LastName = "test",
            UserStatus = true,
            CreatedBy = "System Super Admin",
            CreatedDate = DateTime.Now
        };

        _userManager.CreateAsync(customerUser, "Admin@123456").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(customerUser, Roles.Admin).GetAwaiter().GetResult();

        //Add permissions into superAdmin user
        // Get all the user existing claims and delete them
        //var claims = await _userManager.GetClaimsAsync(adminUser);
        //if(claims != null)
        //     await _userManager.RemoveClaimsAsync(adminUser, claims);

        //// Add all the claims that are selected on the UI
        //var allPermissions = GetAllClaimsPermissions.GetAllControllerActionsUpdated();
        //await _userManager.AddClaimsAsync(adminUser, allPermissions);        
    }

    
}

