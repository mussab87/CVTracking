using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace App.Web.Controllers
{
    [Authorize(Roles = Roles.SuperAdmin)]
    public class SuperAdminController : BaseController
    {
        public SuperAdminController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager,
           IConfiguration _config, IMediator _mediator, IMapper _mapper) : base(_userManager, _signInManager, _roleManager, _config, _mediator, _mapper)
        { }

        [Authorize("Permission-Index")]
        public async Task<IActionResult> Index()

        {
            var query = new GetRootCompanyQuery();
            var RootCompany = await _mediator.Send(query);

            var SuperAdminCount = new SuperAdminCountDto()
            {
                RolesCount = _roleManager.Roles.Count(),
                UserCount = _userManager.Users.Count(),
                RootCompanyCount = RootCompany.Count()
            };
            return View(SuperAdminCount);
        }

        #region Role Section
        /**************Role Section******************************************/
        [HttpGet]
        [Authorize("Permission-ListRoles")]
        public IActionResult ListRoles()
        {
            return View(_roleManager.Roles);
        }

        [Authorize("Permission-CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                Microsoft.AspNetCore.Identity.IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    TempData["Message"] = 1;
                    return RedirectToAction("ListRoles");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        [Authorize("Permission-EditRole")]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleDto
            {
                Id = role.Id,
                RoleName = role.Name
            };

            return View(model);
        }

        // This action responds to HttpPost and receives EditRoleViewModel
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleDto model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    TempData["Message"] = 1;
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpPost]
        [Authorize("Permission-DeleteRole")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var model = new EditRoleDto();
                //Retrieve all the Users then check someone has that role
                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        model.Users.Add(user.UserName);
                        break;
                    }
                }
                if (model.Users.Count > 0)
                {
                    TempData["Message"] = 4;
                    return RedirectToAction("ListRoles");
                }

                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    TempData["Message"] = 1;
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRoles");
            }
        }

        [HttpGet]
        [Authorize("Permission-EditUsersInRole")]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleDto>();

            foreach (var user in _userManager.Users)
            {
                var userRoleViewModel = new UserRoleDto
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstLastName = user.FirstName + " " + user.LastName,

                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return PartialView("_EditUsersInRolePartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRoleAsync(List<UserRoleDto> model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);

                Microsoft.AspNetCore.Identity.IdentityResult result = null;

                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        /**************End Role Section******************************************/
        #endregion

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

            var roleList = _roleManager.Roles.Where(r => r.Name != "R" && r.Name != "C" && r.Name != "I" & r.Name != "A");

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

        [HttpGet]
        [Authorize("Permission-AddUserToRootCompany")]
        public async Task<IActionResult> AddUserToRootCompany(string Id)
        {
            if (Id == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {Id} cannot be found";
                return View("NotFound");
            }

            var selectedUser = await _userManager.FindByIdAsync(Id);

            var query = new GetRootCompanyQuery();
            var RootCompany = await _mediator.Send(query);

            ViewData["RootCompany"] = new SelectList(RootCompany, "Id", "RootCompanyName");

            AddUserToRootCompanyRequest userRootCompanyDto = new AddUserToRootCompanyRequest()
            { ApplicationUserId = Id, applicationUser = selectedUser };

            return View(userRootCompanyDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRootCompany(AddUserToRootCompanyRequest userRootCompanyDto)
        {
            if (userRootCompanyDto.ApplicationUserId == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userRootCompanyDto.ApplicationUserId} cannot be found";
                return View("NotFound");
            }

            var query = new AddUserToRootCompanyRequest()
            { ApplicationUserId = userRootCompanyDto.ApplicationUserId, RootCompanyId = userRootCompanyDto.RootCompanyId };
            var Countries = await _mediator.Send(query);

            TempData["Message"] = 1;
            return RedirectToAction(nameof(ListUsers));
        }

        /**************End User Section******************************************/
        #endregion

        #region RootCompany Section
        [HttpGet]
        [Authorize("Permission-RootCompanyList")]
        public async Task<IActionResult> RootCompanyList()
        {
            var query = new GetUserRootCompanyListQuery();
            var UserRootCompany = await _mediator.Send(query);

            return View(UserRootCompany);
        }

        [HttpGet]
        [Authorize("Permission-AddNewRootCompany")]
        public async Task<IActionResult> AddNewRootCompany()
        {
            var query = new GetCountryListQuery();
            var Countries = await _mediator.Send(query);
            ViewData["Countries"] = new SelectList(Countries, "Id", "NameEnglish");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRootCompany(AddRootCompanyRequest model, IFormFile fileload)
        {
            string fileName = null;
            if (fileload != null)
            {
                fileName = await SaveLogoFile(fileload);
                model.RootCompanyLogo = fileName;
            }

            //save new rootCompany
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            model.CreatedById = LoggedInuser.Id;
            model.CreatedDate = DateTime.Now;


            var newRootCompany = await _mediator.Send(model);
            TempData["Message"] = 1;

            var query = new GetCountryListQuery();
            var Countries = await _mediator.Send(query);
            ViewData["Countries"] = new SelectList(Countries, "Id", "NameEnglish");

            return View();
        }

        static async Task<string> SaveLogoFile(IFormFile fileload)
        {
            string path = Path.Combine("wwwroot/Logo/");
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

            return fileNameWithPath.Replace("wwwroot", "..");
        }

        [HttpGet]
        [Authorize("Permission-EditRootCompany")]
        public async Task<IActionResult> EditRootCompany(int id)
        {
            var queryGetRootCompanyList = new GetRootCompanyQuery();
            var RootCompanyList = await _mediator.Send(queryGetRootCompanyList);

            var queryCountries = new GetCountryListQuery();
            var Countries = await _mediator.Send(queryCountries);
            ViewData["Countries"] = new SelectList(Countries, "Id", "NameEnglish");

            return View(_mapper.Map<UpdateRootCompanyRequest>(RootCompanyList.FirstOrDefault(i => i.Id == id)));
        }

        [HttpPost]
        public async Task<IActionResult> EditRootCompany(UpdateRootCompanyRequest model, IFormFile fileload)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //check file changed at first step
            string fileName = null;
            if (fileload != null)
            {
                fileName = await SaveLogoFile(fileload);
                model.RootCompanyLogo = fileName;
            }

            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            model.CreatedById = LoggedInuser.Id;
            model.LastModifiedDate = DateTime.Now;


            await _mediator.Send(model);
            TempData["Message"] = 1;

            return RedirectToAction(nameof(RootCompanyList));

        }

        [HttpPost]
        [Authorize("Permission-DeleteRootCompany")]
        public async Task<IActionResult> DeleteRootCompany(int id)
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

            var command = new DeleteRootCompanyRequest() { Id = id };
            await _mediator.Send(command);

            TempData["Message"] = 1;

            return RedirectToAction(nameof(RootCompanyList));

        }
        #endregion

    }
}
