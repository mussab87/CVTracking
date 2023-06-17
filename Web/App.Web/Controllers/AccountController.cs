using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System;
using MediatR;
using AutoMapper;
using App.Application.Features.RootCompany.Queries.GetRootCompanyByUserId;
using App.Application.Features.RootCompany.Queries.GetRootCompanyById;

namespace App.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager,
            IConfiguration _config, IMediator _mediator, IMapper _mapper) : base(_userManager, _signInManager, _roleManager, _config, _mediator, _mapper)
        { }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl, LoginDto model)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Username, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        //ModelState.AddModelError(string.Empty, "User Can't Login Please Contact IT Department");
                        //TempData["Message"] = 7;
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        var userName = model.Username;
                        ApplicationUser user = await _userManager.FindByNameAsync(userName);

                        //check if user blocked
                        if (user.UserStatus == false || user.UserStatus == null)
                        {
                            await _signInManager.SignOutAsync();
                            TempData["Message"] = 8;
                            return View(model);
                        }

                        if (_userManager.IsInRoleAsync(user, Roles.SuperAdmin).Result)
                            return RedirectToAction("Index", "SuperAdmin");

                        if (_userManager.IsInRoleAsync(user, Roles.Admin).Result)
                        {
                            await SetRootCompanyForeignAgentSession(user);

                            return RedirectToAction("RootCompany", "RootCompany");
                        }


                        if (_userManager.IsInRoleAsync(user, Roles.ForeignAgent).Result)
                        {
                            await SetRootCompanyForeignAgentSession(user, "foreignAgent");
                            return RedirectToAction("ForeignAgentHome", "ForeignAgent");
                        }

                        if (_userManager.IsInRoleAsync(user, Roles.LocalAgent).Result)
                        {
                            await SetRootCompanyForeignAgentSession(user, null, "localAgent");
                            return RedirectToAction("LocalAgentHome", "LocalAgent");
                        }

                    }

                }
                return LocalRedirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            return LocalRedirect(returnUrl);
        }

        private async Task SetRootCompanyForeignAgentSession(ApplicationUser user, string foreignAgent = null, string localAgent = null)
        {
            //get user root company 
            var query = new GetRootCompanyByIdQuery() { RootCompanyId = (int)user.RootCompanyId };
            var UserRootCompany = await _mediator.Send(query);

            //set session for rootCompany
            HttpContext.Session.SetObject("RootCompany", UserRootCompany);

            //set session for ForeginAgent 
            if (foreignAgent is not null)
            {
                var queryForeignAgent = new GetForeignAgentByIdQuery() { ForeignAgentId = (int)user.ForeignAgentId };
                var UserForeignAgent = await _mediator.Send(queryForeignAgent);

                HttpContext.Session.SetObject("ForeignAgent", UserForeignAgent);
            }

            //set session for LocalAgent 
            if (localAgent is not null)
            {
                var queryLocalAgent = new GetLocalAgentByIdQuery() { LocalAgentId = (int)user.LocalAgentId };
                var UserLocalAgent = await _mediator.Send(queryLocalAgent);

                HttpContext.Session.SetObject("LocalAgent", UserLocalAgent);
            }
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            //log every user login in db
            //var user = await userManager.GetUserAsync(User);

            //UserTransaction userLoggedIn = new UserTransaction();
            //userLoggedIn.UserId = user.Id;
            //userLoggedIn.LoggedOutDateTime = DateTime.Now;

            //await _context.UserTransaction.AddAsync(userLoggedIn);
            //await _context.SaveChangesAsync(User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            HttpContext.Session.Remove("RootCompany");
            HttpContext.Session.Remove("ForeignAgent");
            HttpContext.Session.Clear();

            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
