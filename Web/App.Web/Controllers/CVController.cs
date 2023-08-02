using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{

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
        [AllowAnonymous]
        public async Task<IActionResult> ViewCV(int id, int cvId, int foreignId)
        {
            AddAddNewForeignCvRequest model2 = await GetCandidateCV(cvId, foreignId);
            return View(model2);
        }

        private async Task<AddAddNewForeignCvRequest> GetCandidateCV(int cvId, int foreignId)
        {
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

            if (model2.cvHRpool.LocalAgentId is not null)
            {
                GetLocalAgentByIdQuery getLocalQuery = new()
                {
                    LocalAgentId = (int)model2.cvHRpool.LocalAgentId
                };
                var localAgent = await _mediator.Send(getLocalQuery);

                model2.cvHRpool.LocalAgent = _mapper.Map<LocalAgent>(localAgent);
            }
            return model2;
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
        [Authorize]
        public async Task<FileResult> OnPostGetPDF(int id, int cvId, int foreignId)
        {
            return await PrepareReportAsync("PDF", "pdf", "application/pdf", id, cvId, foreignId, false);
        }
        [Authorize]
        public async Task<FileResult> OnPostGetImg(int id, int cvId, int foreignId)
        {
            return await PrepareReportAsync("Image", "jpg", "image/jpg", id, cvId, foreignId, true);
        }

        //public IActionResult OnPostGetDOCX() => PrepareReport("WORDOPENXML", "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        //public IActionResult OnPostGetHTML() => PrepareReport("HTML5", "html", "text/html");        
        //public IActionResult OnPostGetXLSX() => PrepareReport("EXCELOPENXML", "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        private async Task<FileResult> PrepareReportAsync(string renderFormat, string extension, string mimeType, int id, int cvId, int foreignId, bool img)
        {
            AddAddNewForeignCvRequest model = await GetCandidateCV(cvId, foreignId);

            Microsoft.Reporting.NETCore.LocalReport report;
            string nameOfFile;

            string requestUrl = HttpContext.Request.GetDisplayUrl();
            string splitImageUrl = $"http://{requestUrl.Split("/")[2]}/";

            GenerateFile(renderFormat, extension, out report, out nameOfFile, model, splitImageUrl);

            if (img)
            {
                byte[] pdf;
                getReport(renderFormat, model, out report, splitImageUrl, out pdf);
                return File(pdf, mimeType, $"{model.cv.CandidateNameEnglish}." + extension);
            }

            return File(nameOfFile, mimeType);
        }

        static void getReport(string renderFormat, AddAddNewForeignCvRequest model, out Microsoft.Reporting.NETCore.LocalReport report, string splitImageUrl, out byte[] pdf)
        {
            report = new Microsoft.Reporting.NETCore.LocalReport();
            ReportViewerCore.Report.Load(report, model, splitImageUrl);
            pdf = report.Render(renderFormat);
        }

        private static void GenerateFile(string renderFormat, string extension, out Microsoft.Reporting.NETCore.LocalReport report, out string nameOfFile, AddAddNewForeignCvRequest model, string splitImageUrl)
        {
            byte[] pdf;
            getReport(renderFormat, model, out report, splitImageUrl, out pdf);

            string path = Path.Combine("wwwroot/CV/");
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = $"{Guid.NewGuid()}.{extension}";
            string fileNameWithPath = Path.Combine(path, fileName);

            System.IO.File.WriteAllBytes(fileNameWithPath, pdf);

            nameOfFile = fileNameWithPath.Replace("wwwroot/", "");
        }
        #endregion
    }
}
