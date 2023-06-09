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
        [Authorize("ForeignAgent-ForeignAgentAllCVList")]
        public async Task<IActionResult> ForeignAgentAllCVList()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("RootCompany");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList);
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentSelectedApplicants")]
        public async Task<IActionResult> ForeignAgentSelectedApplicants()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("RootCompany");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList.Where(s => s.CVStatus.Status == "Selected"));
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentPostToAdminApplicants")]
        public async Task<IActionResult> ForeignAgentPostToAdminApplicants()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("RootCompany");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList.Where(s => s.CVStatus.Status == "Post to Admin"));
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentInCompleteCV")]
        public async Task<IActionResult> ForeignAgentInCompleteCV()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("RootCompany");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList.Where(s => s.CVStatus.Status == "InComplete"));
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentBackoutCV")]
        public async Task<IActionResult> ForeignAgentBackoutCV()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("RootCompany");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList.Where(s => s.CVStatus.Status == "Backout"));
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentAddNewCV")]
        public async Task<IActionResult> ForeignAgentAddNewCV()
        {
            await GetDropDownList();
            return View();
        }

        async Task GetDropDownList()
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
