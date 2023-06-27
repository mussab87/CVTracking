using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

            //get all CV for the ForeignAgent
            //var query = new GetAllCvListQuery() { ForeignAgentId = (int)LoggedInuser.ForeignAgentId };
            //var ForeignAgentCvList = await _mediator.Send(query);

            //var ForeignAgentCount = new FoerignAgentCountDto()
            //{
            //    CvCount = ForeignAgentCvList.Count(),
            //    PostToAdminCount = ForeignAgentCvList.Where(s => s.CVStatus.StatusNo == (int)cvStatus.PostToAdmin).Count(),
            //    SelectedCvCount = ForeignAgentCvList.Where(s => s.CVStatus.StatusNo == (int)cvStatus.Selected).Count()
            //};

            return View();
            //return View(ForeignAgentCount);
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
            var command = new UpdateLocalSelectedCvSponsorDataRequest()
            {
                HRPoolId = id,
                LocalAgentId = userLocalAgentId.Id,
                CreatedById = LoggedInuser.Id,
                sponsorName = sponsorname,
                sponsorIDNumber = idnumber,
                sponsorContact = contact,
                sponsorVisaNumber = visano,
                SponsorDateOfBirth = Convert.ToDateTime(sponsordateofbirth)
            };
            var commandResult = await _mediator.Send(command);

            TempData["Message"] = 1;
            return RedirectToAction("LocalAgentAllCVList");
        }


        #endregion
    }
}
