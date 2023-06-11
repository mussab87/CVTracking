using App.Application.Features.RootCompany.Queries.GetRootCompanyByUserId;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

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

            //configure reference number - first 2 digit from ForeignAgent name + 0000100
            var userForeignAgent = HttpContext.Session.GetObject<ForegnAgentDto>("ForeignAgent");
            var twoDigitFromName = userForeignAgent.ForeignAgentName.ToUpper().Substring(0, 2);

            //get last cv reference number for add plus one into the number
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgent.Id };
            var ForeignAgentCvList = await _mediator.Send(query);
            string refNo = null;
            if (ForeignAgentCvList.Count > 0)
            {
                var lastCvRefNo = ForeignAgentCvList.OrderBy(r => r.CV.Id).Last().CV.CvReferenceNumber;
                var removeTwoDigit = lastCvRefNo.Substring(2, 9);
                refNo = twoDigitFromName + (Convert.ToInt64(removeTwoDigit) + 1).ToString();
            }
            else
            {
                refNo = twoDigitFromName + "0000100";
            }
            AddAddNewForeignCvRequest model = new() { cv = new CVDto() { CvReferenceNumber = refNo } };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ForeignAgentAddNewCV(AddAddNewForeignCvRequest model,
                                                        IFormFile personalphoto, IFormFile posterphoto, IFormFile passportphoto)
        {
            await GetDropDownList();
            return View(model);
        }

        async Task GetDropDownList()
        {
            //Countries
            var country = new GetCountryListQuery();
            var Countries = await _mediator.Send(country);
            ViewData["Countries"] = new SelectList(Countries, "Id", "NameEnglish");
            ViewBag.Country = JsonSerializer.Serialize(Countries.Select(c => new
            {
                Id = c.Id,
                country = c.NameEnglish
            }).ToList());

            //Cities
            var city = new GetCityListQuery();
            var Cities = await _mediator.Send(city);
            ViewData["Cities"] = new SelectList(Cities, "Id", "NameEnglish");

            //Religions
            var religion = new GetReligionListQuery();
            var religions = await _mediator.Send(religion);
            ViewData["Religion"] = new SelectList(religions, "Id", "ReligionEnglish");

            //MartialStatus
            var martialStatus = new GetMartialStatusListQuery();
            var martials = await _mediator.Send(martialStatus);
            ViewData["martialStatus"] = new SelectList(martials, "Id", "MartialStatusEnglish");
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
