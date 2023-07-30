using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Security.Cryptography;

namespace App.Web.Controllers
{
    [Authorize(Roles = Roles.LocalAgent)]
    public class LocalAgentController : BaseController
    {
        public LocalAgentController(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager,
           IConfiguration _config, IMediator _mediator, IMapper _mapper) : base(_userManager, _signInManager, _roleManager, _config, _mediator, _mapper)
        { }

        [Authorize("LocalAgent-LocalAgentHome")]
        public async Task<IActionResult> LocalAgentHome()
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            var userLocalAgentId = HttpContext.Session.GetObject<LocalAgentDto>("LocalAgent").Id;

            var queryGetAllCv = new GetAllCvListLocalQuery() { LocalAgentId = userLocalAgentId };
            var GetAllCvResult = await _mediator.Send(queryGetAllCv);

            var query = new GetForeignAgentListQuery() { rootCompanyId = (int)LoggedInuser.RootCompanyId };
            var ForeignAgentListByRootCompany = await _mediator.Send(query);

            //get cancel notification
            List<CountCancelCVDto> CountCancel = GetNotificationCV(LoggedInuser, GetAllCvResult);

            LocalAgentHomeDto localAgentHomeDto = new();
            localAgentHomeDto.LocalHrPool = GetAllCvResult;
            localAgentHomeDto.ForegnAgent = ForeignAgentListByRootCompany;
            localAgentHomeDto.CountCancel = CountCancel;

            return View(localAgentHomeDto);
        }

        private static List<CountCancelCVDto> GetNotificationCV(ApplicationUser LoggedInuser, List<LocalAgentHRPoolDto> GetAllCvResult)
        {
            List<CountCancelCVDto> CountCancel = new();
            if (GetAllCvResult.Count > 0)
            {
                foreach (var hrcv in GetAllCvResult.Where(c => c.CVStatus.StatusNo == (int)cvStatus.Canceled))
                {
                    var personalImg = hrcv.cvAttachments
                                    .Where(p => p.Attachment.AttachmentType.TypeName == cvAttachmentType.PersonalPhoto.ToString())
                                    .FirstOrDefault();
                    var objCancel = new CountCancelCVDto();

                    objCancel.RootCompanyId = (int)LoggedInuser.RootCompanyId;
                    objCancel.LocalAgentId = hrcv.LocalAgent is not null ? hrcv.LocalAgent.Id : null;
                    objCancel.ForeignAgentId = hrcv.ForeignAgent is not null ? hrcv.ForeignAgent.Id : null;
                    objCancel.ForeignAgentName = hrcv.ForeignAgent is not null ? hrcv.ForeignAgent.ForeignAgentName : null;
                    objCancel.HRPoolId = hrcv.Id;
                    objCancel.CVId = hrcv.CV.Id;
                    objCancel.SelectedId = hrcv.selected is not null ? hrcv.selected.Id : null;
                    objCancel.ApplicantName = hrcv.CV.CandidateNameEnglish;
                    objCancel.ApplicantPersonalImg = personalImg.Attachment.Path;
                    objCancel.CVStatus = hrcv.CVStatus.Status;
                    objCancel.LocalSelectedStatus = hrcv.selected is not null ? hrcv.selected.LocalAgentStatusId.ToString() : null;
                    objCancel.CancellationDateTime = hrcv.CancelDateTime is not null ? hrcv.CancelDateTime : null;

                    if (hrcv.selected is not null)
                    {
                        if (hrcv.selected.LocalAgentStatusId == (int)cvStatus.Selected
                            || hrcv.selected.LocalAgentStatusId == (int)cvStatus.Employeed)
                        {
                            objCancel.CancelledReason = hrcv.CancelReason is not null ? hrcv.CancelReason.CancelReasonEnglish : null;
                            objCancel.SponsorName = hrcv.selected is not null ? hrcv.selected.SponsorName : null;
                            objCancel.SponsorContact = hrcv.selected is not null ? hrcv.selected.SponsorContact : null;
                            objCancel.SponsorVisaNumber = hrcv.selected is not null ? hrcv.selected.VisaNumber : null;
                            objCancel.SponsorDateofBirth = hrcv.selected is not null ? hrcv.selected.SponsorDateOfBirthHijri.Value.ToString("dd/MM/yyyy") : null;
                            objCancel.SponsorIdNumber = hrcv.selected is not null ? hrcv.selected.SponsorIdNumber : null;
                        }
                    }

                    CountCancel.Add(objCancel);
                }
            }

            return CountCancel;
        }

        #region LocalAgent CV Section

        [HttpGet]
        [Authorize("LocalAgent-LocalAgentAllCVList")]
        public async Task<IActionResult> LocalAgentAllCVList()
        {
            var userLocalAgentId = HttpContext.Session.GetObject<LocalAgentDto>("LocalAgent").Id;

            //get all CV for the local agent under cvStatus SendToLocal
            var queryGetAllCv = new GetAllCvListLocalQuery() { LocalAgentId = userLocalAgentId };
            var GetAllCvResult = await _mediator.Send(queryGetAllCv);

            return View(GetAllCvResult);
        }

        [HttpGet]
        [Authorize("LocalAgent-LocalAgentSelectCV")]
        public async Task<IActionResult> LocalAgentSelectCV(int id, int cvId, int foreignId)
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            var userLocalAgentId = HttpContext.Session.GetObject<LocalAgentDto>("LocalAgent");

            //add selected cv into selected table 
            var command = new AddLocalSelectedCVRequest()
            {
                HRPoolId = id,
                LocalAgentId = userLocalAgentId.Id,
                CreatedById = LoggedInuser.Id
            };
            var commandResult = await _mediator.Send(command);

            TempData["Message"] = 1;
            return RedirectToAction("LocalAgentAllCVList");
        }

        [HttpGet]
        [Authorize("LocalAgent-LocalAgentUnSelectCV")]
        public async Task<IActionResult> LocalAgentUnSelectCV(int id, int cvId, int foreignId)
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            var userLocalAgentId = HttpContext.Session.GetObject<LocalAgentDto>("LocalAgent");

            //add selected cv into selected table 
            var command = new UpdateLocalUnSelectedCVRequest()
            {
                HRPoolId = id,
                LocalAgentId = userLocalAgentId.Id,
                CreatedById = LoggedInuser.Id
            };
            var commandResult = await _mediator.Send(command);

            TempData["Message"] = 1;
            return RedirectToAction("LocalAgentAllCVList");
        }

        [HttpGet]
        [Authorize("LocalAgent-LocalAgentProcessSponsorData")]
        public async Task<IActionResult> LocalAgentProcessSponsorData(int id, int cvId, int foreignId, string sponsorname, string idnumber,
                            string visano, string contact, string sponsordateofbirth)
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            var userLocalAgentId = HttpContext.Session.GetObject<LocalAgentDto>("LocalAgent");

            //add selected cv into selected table 

            DateTime sponsorDateOfBirthgregorian, gregorianDateTime;
            ConvertDateOfBirth(sponsordateofbirth, out sponsorDateOfBirthgregorian, out gregorianDateTime);

            var command = new UpdateLocalSelectedCvSponsorDataRequest()
            {
                HRPoolId = id,
                LocalAgentId = userLocalAgentId.Id,
                CreatedById = LoggedInuser.Id,
                sponsorName = sponsorname,
                sponsorIDNumber = idnumber,
                sponsorContact = contact,
                sponsorVisaNumber = visano,
                SponsorDateOfBirth = gregorianDateTime,
                SponsorDateOfBirthHijri = sponsorDateOfBirthgregorian
            };
            var commandResult = await _mediator.Send(command);

            TempData["Message"] = 1;
            return RedirectToAction("LocalAgentAllCVList");
        }

        static void ConvertDateOfBirth(string sponsordateofbirth, out DateTime sponsorDateOfBirthgregorian, out DateTime gregorianDateTime)
        {
            //convert date from hijri into georgian
            System.Globalization.CultureInfo gregorianCulture = new System.Globalization.CultureInfo("en-US");
            System.Globalization.CultureInfo hijriCulture = new System.Globalization.CultureInfo("ar-SA");

            sponsorDateOfBirthgregorian = DateTime.ParseExact(sponsordateofbirth, "yyyy/MM/dd", gregorianCulture.DateTimeFormat,
                System.Globalization.DateTimeStyles.AllowInnerWhite);

            // Convert the Hijri date to the Gregorian calendar
            gregorianDateTime = hijriCulture.Calendar.ToDateTime(sponsorDateOfBirthgregorian.Year, sponsorDateOfBirthgregorian.Month, sponsorDateOfBirthgregorian.Day, 0, 0, 0, 0);
        }


        [HttpGet]
        [Authorize("LocalAgent-SendCVByWhatsApp")]
        public async Task<IActionResult> SendCVByWhatsApp(int id)
        {
            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            var userLocalAgentId = HttpContext.Session.GetObject<LocalAgentDto>("LocalAgent");

            var command = new UpdateLocalSendByWhatsAppRequest()
            {
                HRPoolId = id,
                LocalAgentId = userLocalAgentId.Id,
                CreatedById = LoggedInuser.Id,
            };
            var commandResult = await _mediator.Send(command);

            TempData["Message"] = 1;
            return Json("done");
        }

        #endregion
    }
}
