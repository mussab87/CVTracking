using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public HomeController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager,
           IConfiguration _config, IMediator _mediator, IMapper _mapper) : base(_userManager, _signInManager, _roleManager, _config, _mediator, _mapper)
        { }
        public IActionResult Index()
        {
            string controller = null;
            string action = null;
            if (_signInManager.IsSignedIn(User) && _signInManager.Context.User.IsInRole(Roles.SuperAdmin))
            {
                controller = "SuperAdmin";
                action = "Index";

                return RedirectToAction(action, controller);
            }
            if (_signInManager.IsSignedIn(User) && _signInManager.Context.User.IsInRole(Roles.Admin))
            {
                controller = "RootCompany";
                action = "RootCompany";

                return RedirectToAction(action, controller);
            }

            return View();
            //return RedirectToAction(action, controller);
        }
    }
}
