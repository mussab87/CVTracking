using App.Application.Features.RootCompany.Queries.GetRootCompanyByUserId;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Web.Controllers
{
    [Authorize(Roles = Roles.ForeignAgent)]
    public class ForeignAgentController : BaseController
    {
        public ForeignAgentController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager,
           IConfiguration _config, IMediator _mediator, IMapper _mapper) : base(_userManager, _signInManager, _roleManager, _config, _mediator, _mapper)
        { }

        [Authorize("ForeignAgent-ForeignAgentHome")]
        public async Task<IActionResult> ForeignAgentHome()
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

            var ForeignAgentCount = new FoerignAgentCountDto()
            {
                CvCount = 0,
                PostToAdminCount = 0,
                SelectedCvCount = 0
            };


            return View(ForeignAgentCount);
        }

        #region ForeignAgent Section
        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentList")]
        public async Task<IActionResult> ForeignAgentList()
        {
            if (HttpContext.Session.GetObject<RootCompanyDto>("RootCompany") is null)
                return RedirectToAction("Logout", "Account");

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
        [Authorize("ForeignAgent-ForeignAgentAddUsers")]
        public async Task<IActionResult> ForeignAgentAddUsers(int foreignId)
        {
            if (HttpContext.Session.GetObject<RootCompanyDto>("RootCompany") is null)
                return RedirectToAction("Logout", "Account");

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
            if (HttpContext.Session.GetObject<RootCompanyDto>("RootCompany") is null)
                return RedirectToAction("Logout", "Account");


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
        [Authorize("ForeignAgent-AddNewForeignAgent")]
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

            if (HttpContext.Session.GetObject<RootCompanyDto>("RootCompany") is null)
                return RedirectToAction("Logout", "Account");

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

            return fileNameWithPath.Replace("wwwroot", "../../");
        }

        [HttpGet]
        [Authorize("ForeignAgent-EditForeignAgent")]
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
        //[Authorize("ForeignAgent-DeleteForeignAgent")]
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
