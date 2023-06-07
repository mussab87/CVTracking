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

        #region ForeignAgent CV Section
        [HttpGet]
        [Authorize("ForeignAgent-AllCVList")]
        public async Task<IActionResult> AllCVList()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("RootCompany");

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

        #endregion
    }
}
