using App.Application.Features.RootCompany.Queries.GetRootCompanyByUserId;
using App.Helper.Dto;
using AspNetCore.Reporting;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SendGrid;
using System.Security.Claims;

namespace App.Web.Controllers
{
    [AllowAnonymous]
    public class CVController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CVController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager,
           IConfiguration _config, IMediator _mediator, IMapper _mapper, IWebHostEnvironment webHostEnvironment) : base(_userManager, _signInManager, _roleManager, _config, _mediator, _mapper)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        #region View CV

        public async Task<IActionResult> ViewCV(int id, int cvId, int foreignId)
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);

            var foreignAgentByIdCommand = new GetForeignAgentByIdQuery() { ForeignAgentId = foreignId };
            var foreignUser = await _mediator.Send(foreignAgentByIdCommand);

            //get exist cv info by CVId
            var queryGetCVById = new GetForeignCvByIdQuery() { cvId = cvId };
            var GetCVById = await _mediator.Send(queryGetCVById);

            var existCvAttachments = await getCVAttachments(GetCVById);
            AddAddNewForeignCvRequest model2 = FillExistForeignCv(foreignUser, GetCVById, existCvAttachments);

            //get nationality from country table
            var queryCountry = new GetCountryListQuery();
            var nationality = await _mediator.Send(queryCountry);
            model2.cv.Nationality = nationality.FirstOrDefault(n => n.Id == model2.cv.NationalityId).NameEnglish;

            //get martial status from martialStatus table
            var queryMartialStatus = new GetMartialStatusListQuery();
            var martialStatus = await _mediator.Send(queryMartialStatus);
            model2.cv.martial = martialStatus.FirstOrDefault(n => n.Id == model2.cv.MartialStatusId).MartialStatusEnglish;

            //get religion from religion table
            var queryreligion = new GetReligionListQuery();
            var religion = await _mediator.Send(queryreligion);
            model2.cv.Religion = religion.FirstOrDefault(n => n.Id == model2.cv.ReligionId).ReligionEnglish;
            return View(model2);
        }

        private async Task<List<Attachment>> getCVAttachments(ForeignAgentHRPoolDto GetCVById)
        {
            var cvAttachments = new List<Attachment>();
            if (GetCVById.cvAttachments.Count > 0)
            {
                foreach (var att in GetCVById.cvAttachments)
                {
                    cvAttachments.Add(att.Attachment);
                }
            }
            return cvAttachments;
        }

        private AddAddNewForeignCvRequest FillExistForeignCv(ForegnAgentDto userForeignAgent, ForeignAgentHRPoolDto GetCVById, List<Attachment> existCvAttachments)
        {

            return new()
            {
                cv = _mapper.Map<CVDto>(GetCVById.CV),
                cvAttachments = existCvAttachments,
                cvHRpool = GetCVById.cvHRpool,
                previousEmployment = GetCVById.previousEmployment.Count > 0 ? GetCVById.previousEmployment : null,
                cvStatusId = GetCVById.CVStatus.Id,
                foreignAgentId = userForeignAgent.Id,
                foreignAgentUserId = userForeignAgent.Id.ToString(),
                HRPoolId = GetCVById.cvHRpool.Id,
                Skills = GetCVById.Skills,
                skillList = GetCVById.skillList,
            };
        }

        #endregion

        #region Print CV
        public IActionResult OnPostGetPDF() => PrepareReport("PDF", "pdf", "application/pdf");
        public IActionResult OnPostGetDOCX() => PrepareReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        public IActionResult OnPostGetImg() => PrepareReport("Image", "jpg", "image/jpg");
        //public IActionResult OnPostGetHTML() => PrepareReport("HTML5", "html", "text/html");        
        //public IActionResult OnPostGetXLSX() => PrepareReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        private IActionResult PrepareReport(string renderFormat, string extension, string mimeType)
        {
            using var report = new Microsoft.Reporting.NETCore.LocalReport();
            ReportViewerCore.Report.Load(report, 5, 10);
            var pdf = report.Render(renderFormat);
            return File(pdf, mimeType, "report." + extension);
        }
        #endregion
    }
}
