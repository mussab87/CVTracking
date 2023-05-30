﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System;

namespace App.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           RoleManager<IdentityRole> _roleManager,
           IConfiguration _config) : base(_userManager, _signInManager, _roleManager, _config)
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
                    }

                }
                return LocalRedirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            return LocalRedirect(returnUrl);
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

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
