﻿using App.Application.Features.RootCompany.Queries.GetRootCompanyByUserId;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Authorize("RootCompany-RootCompany")]
        public async Task<IActionResult> RootCompany()
        {
            //var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

            var UserRootCompany = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany");
            //get ForeignAgentsCount
            var ForeignCount = new GetForeignAgentListQuery() { rootCompanyId = (int)UserRootCompany.Id };
            var ForeignAgentListByRootCompany = await _mediator.Send(ForeignCount);

            var RootCompanyCount = new RootCompanyCountDto()
            {
                UserCount = _userManager.Users.Where(u => u.RootCompanyId == UserRootCompany.Id).ToList().Count(),
                FoeignAgentCount = ForeignAgentListByRootCompany.Count()
            };

            return View(RootCompanyCount);
        }

        #region User Section
        /**************User Section******************************************/
        [HttpGet]
        [Authorize("RootCompany-ListUsers")]
        public IActionResult ListUsers()
        {
            var userRootCompany = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            return View(_userManager.Users.Where(u => u.RootCompanyId == userRootCompany));

        }

        [Authorize("RootCompany-AddNewAccount")]
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

                var userRootCompany = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;

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
                    CreatedBy = LoggedInuser.UserName,
                    RootCompanyId = userRootCompany
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

        [Authorize("RootCompany-ChangeUserPassword")]
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
        [Authorize("RootCompany-DeleteUser")]
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
        [Authorize("RootCompany-EditUser")]
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
        [Authorize("RootCompany-ManageUserRoles")]
        public async Task<IActionResult> ManageUserRoles(string Id)
        {
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
        [Authorize("RootCompany-ManageUserPermission")]
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
            foreach (Claim claim in GetAllClaimsPermissions.GetAllControllerActionsUpdated())
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

        #region ForeignAgent Section
        [HttpGet]
        [Authorize("RootCompany-ForeignAgentList")]
        public async Task<IActionResult> ForeignAgentList()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;

            var query = new GetForeignAgentListQuery() { rootCompanyId = (int)userRootCompanyId };
            var ForeignAgentListByRootCompany = await _mediator.Send(query);

            //get all users inside selected rootCompany           
            var rootCompanyUsers = _userManager.Users.Where(u => u.RootCompanyId == userRootCompanyId);

            //forloop inside users for check foreignAgent
            foreach (var user in rootCompanyUsers)
            {
                foreach (var foreign in ForeignAgentListByRootCompany)
                {
                    if (user.ForeignAgentId == foreign.Id)
                        foreign.ForeignAgentUsers.Add(user);
                }

            }

            return View(ForeignAgentListByRootCompany);
        }

        [HttpGet]
        [Authorize("RootCompany-ForeignAgentAddUsers")]
        public async Task<IActionResult> ForeignAgentAddUsers(int foreignId)
        {
            var foreignAgentQuery = new GetForeignAgentByIdQuery() { ForeignAgentId = foreignId };
            var foreignAgent = await _mediator.Send(foreignAgentQuery);

            if (foreignAgent == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {foreignId} cannot be found";
                return View("NotFound");
            }

            //get all users inside selected rootCompany
            var userRootCompany = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var rootCompanyUsers = _userManager.Users.Where(u => u.RootCompanyId == userRootCompany);

            UserAgentDto model = new()
            {
                foreignAgentId = foreignId
            };

            // Loop through each user
            foreach (var user in rootCompanyUsers)
            {
                UserAgent userForeign = new()
                {
                    UserId = user.Id,
                    userName = user.FirstName + user.LastName
                };

                // If the user has assigned into selected foreignCompany, set IsSelected property to true, so the checkbox
                // next to the user is checked on the UI
                if (rootCompanyUsers.Any(c => c.ForeignAgentId == foreignId))
                {
                    userForeign.IsSelected = true;
                }

                model.usersAgents.Add(userForeign);
            }

            return PartialView("_ForeignAgentAddUsers", model);

        }

        [HttpPost]
        public async Task<IActionResult> ForeignAgentAddUsers(UserAgentDto model)
        {

            //get all users inside selected rootCompany
            var userRootCompany = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var rootCompanyUsers = _userManager.Users.Where(u => u.RootCompanyId == userRootCompany
                                        && u.ForeignAgentId == model.foreignAgentId).ToList();

            //remove existing ForeignCompany Users
            if (rootCompanyUsers.Count() > 0)
            {
                foreach (var item in rootCompanyUsers)
                {
                    var user = await _userManager.FindByIdAsync(item.Id);
                    user.ForeignAgentId = null;
                    await _userManager.UpdateAsync(user);
                }
            }

            foreach (var userSelected in model.usersAgents)
            {
                var user = await _userManager.FindByIdAsync(userSelected.UserId);

                user.ForeignAgentId = model.foreignAgentId;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    TempData["Message"] = 1;
                    return RedirectToAction(nameof(ForeignAgentList));
                }
            }

            TempData["Message"] = 5;
            return View(model);
        }

        [HttpGet]
        [Authorize("RootCompany-AddNewForeignAgent")]
        public async Task<IActionResult> AddNewForeignAgent()
        {
            var query = new GetCityListQuery();
            var Cities = await _mediator.Send(query);
            ViewData["Cities"] = new SelectList(Cities, "Id", "NameEnglish");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewForeignAgent(AddForeignAgentRequest model, IFormFile fileload)
        {
            if (!ModelState.IsValid)
            {
                await GetCities();
                return View(model);

            }

            //if(model.ForeignAgentCountryCityId ==)

            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;

            string fileName = null;
            if (fileload != null)
            {
                fileName = await SaveLogoFile(fileload);
                model.ForeignAgentLogo = fileName;
            }

            //save new rootCompany
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            model.CreatedById = LoggedInuser.Id;
            model.CreatedDate = DateTime.Now;
            model.RootCompanyId = (int)userRootCompanyId;

            var newForeignAgent = await _mediator.Send(model);
            TempData["Message"] = 1;

            await GetCities();

            return View();


        }

        async Task GetCities()
        {
            var query = new GetCityListQuery();
            var Cities = await _mediator.Send(query);
            ViewData["Cities"] = new SelectList(Cities, "Id", "NameEnglish");
        }

        static async Task<string> SaveLogoFile(IFormFile fileload)
        {
            string path = Path.Combine("wwwroot/ForeignLogo/");
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo fileInfo = new FileInfo(fileload.FileName);

            string fileName = fileload.FileName.Split(".")[0] + string.Format(@"{0}", Guid.NewGuid()) + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.CreateNew))
            {
                await fileload.CopyToAsync(stream);
            }

            return fileNameWithPath.Replace("wwwroot", "../..");
        }

        [HttpGet]
        [Authorize("RootCompany-EditForeignAgent")]
        public async Task<IActionResult> EditForeignAgent(int id)
        {
            var foreignAgentQuery = new GetForeignAgentByIdQuery() { ForeignAgentId = id };
            var foreignAgent = await _mediator.Send(foreignAgentQuery);

            await GetCities();

            return View(_mapper.Map<UpdateForeignAgentRequest>(foreignAgent));
        }

        [HttpPost]
        public async Task<IActionResult> EditForeignAgent(UpdateForeignAgentRequest model, IFormFile fileload)
        {
            if (!ModelState.IsValid)
            {
                await GetCities();
                return View(model);
            }

            //check file changed at first step
            string fileName = null;
            if (fileload != null)
            {
                fileName = await SaveLogoFile(fileload);
                model.ForeignAgentLogo = fileName;
            }

            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            model.LastModifiedById = LoggedInuser.Id;
            model.LastModifiedDate = DateTime.Now;

            await _mediator.Send(model);
            TempData["Message"] = 1;

            return RedirectToAction(nameof(ForeignAgentList));
        }

        //[HttpPost]
        //[Authorize("RootCompany-DeleteForeignAgent")]
        //public async Task<IActionResult> DeleteForeignAgent(int id)
        //{
        //    var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

        //    var command = new DeleteRootCompanyRequest() { Id = id };
        //    await _mediator.Send(command);

        //    TempData["Message"] = 1;

        //    return RedirectToAction(nameof(ForeignAgentList));

        //}
        #endregion
    }
}
