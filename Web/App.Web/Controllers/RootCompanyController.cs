using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.Web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class RootCompanyController : BaseController
    {
        public RootCompanyController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager,
           IConfiguration _config, IMediator _mediator, IMapper _mapper) : base(_userManager, _signInManager, _roleManager, _config, _mediator, _mapper)
        { }

        [Authorize("Permission-RootCompany")]
        public IActionResult RootCompany()
        {
            var SuperAdminCount = new SuperAdminCountDto()
            {
                RolesCount = _roleManager.Roles.Count(),
                UserCount = _userManager.Users.Count()
            };
            return View(SuperAdminCount);
        }

        #region User Section
        /**************User Section******************************************/
        [HttpGet]
        [Authorize("Permission-ListUsers")]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            //var users = userManager.Users
            //    .Include(a => a.UserJobTitle)
            //    .ThenInclude(g => g.JobTitle)
            //    .ToListAsync().Result;
            return View(users);
        }

        [Authorize("Permission-AddNewAccount")]
        public IActionResult AddNewAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAccount(AccountDto model)
        {
            if (ModelState.IsValid)
            {
                var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FirstNameArabic = model.FirstNameArabic,
                    LastNameArabic = model.LastNameArabic,
                    PhoneNumber = model.PhoneNumber,
                    UserStatus = model.UserStatus,
                    CreatedDate = DateTime.Now,
                    CreatedBy = LoggedInuser.UserName
                };

                // Store user data in AspNetUsers database table
                var result = await _userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    TempData["Message"] = 1;
                    return RedirectToAction("EditUser", new { Id = user.Id });
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {

                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use.");
            }
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsUsernameInUse(string Username)
        {
            var user = await _userManager.FindByNameAsync(Username);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Username {Username} is already in use.");
            }
        }

        [Authorize("Permission-ChangeUserPassword")]
        [HttpGet]
        public async Task<IActionResult> ChangeUserPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ChangePasswordDto model = new ChangePasswordDto
            {
                Id = user.Id,
                username = user.UserName,
                Name = user.FirstName + " " + user.LastName
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordDto model, string Id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

                // Upon successfully changing the password refresh sign-in cookie
                //await signInManager.RefreshSignInAsync(user);

                TempData["Message"] = 1;
                return RedirectToAction("ListUsers");
            }
            //TempData["Message"] = 10;

            return View(model);
        }

        [HttpPost]
        [Authorize("Permission-DeleteUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.UserStatus = false;
                user.LastModifiedBy = LoggedInuser.UserName;
                user.LastModifiedDate = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        [HttpGet]
        [Authorize("Permission-EditUser")]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await _userManager.GetClaimsAsync(user);

            // GetRolesAsync returns the list of user Roles
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FirstNameArabic = user.FirstNameArabic,
                LastNameArabic = user.LastNameArabic,
                PhoneNumber = user.PhoneNumber,
                UserStatus = user.UserStatus,

                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserDto model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }


            user.Email = model.Email;
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.FirstNameArabic = model.FirstNameArabic;
            user.LastNameArabic = model.LastNameArabic;
            user.PhoneNumber = model.PhoneNumber;
            user.UserStatus = model.UserStatus;
            user.LastModifiedBy = LoggedInuser.UserName;
            user.LastModifiedDate = DateTime.Now;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Message"] = 1;
                return RedirectToAction("EditUser", new { Id = model.Id });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            TempData["Message"] = 5;
            return View(model);
        }

        [HttpGet]
        [Authorize("Permission-ManageUserRoles")]
        public async Task<IActionResult> ManageUserRoles(string Id)
        {
            //ViewBag.userId = Id;

            var user = await _userManager.FindByIdAsync(Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {Id} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesDto>();

            var roleList = _roleManager.Roles.Where(r => r.Name != Roles.SuperAdmin);

            foreach (var role in roleList) //roleManager.Roles
            {
                var userRolesViewModel = new UserRolesDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    UserId = Id
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return PartialView("_ManageUserRolesPartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesDto> model, string UserId)
        {
            UserId = model[0].UserId;
            var user = await _userManager.FindByIdAsync(UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {UserId} cannot be found";
                return View("NotFound");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            TempData["Message"] = 1;
            return RedirectToAction("EditUser", new { Id = UserId });
        }

        [HttpGet]
        [Authorize("Permission-ManageUserPermission")]
        public async Task<IActionResult> ManageUserPermission(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            // UserManager service GetClaimsAsync method gets all the current claims of the user
            var existingUserClaims = await _userManager.GetClaimsAsync(user);

            var model = new UserClaimsDto
            {
                UserId = userId
            };

            // Loop through each claim we have in our application
            //foreach (Claim claim in ClaimsStore.AllClaims)
            foreach (Claim claim in ShardFunctions.GetAllControllerActionsUpdated())
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                // If the user has the claim, set IsSelected property to true, so the checkbox
                // next to the claim is checked on the UI
                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }

                model.Cliams.Add(userClaim);
            }

            return PartialView("_ManageUserPermissionPartial", model);

        }

        [HttpPost]
        public async Task<IActionResult> ManageUserPermission(UserClaimsDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
                return View("NotFound");
            }

            // Get all the user existing claims and delete them
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            // Add all the claims that are selected on the UI
            result = await _userManager.AddClaimsAsync(user,
                model.Cliams.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = model.UserId });

        }

        /**************End User Section******************************************/
        #endregion
    }
}
