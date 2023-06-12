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
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("ForeignAgent");

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
        public async Task<IActionResult> ForeignAgentAddNewCV(int id)
        {
            //add new cv
            if (id == 0)
            {
                await GetDropDownList();
                var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
                //configure reference number - first 2 digit from ForeignAgent name + 0000100
                var userForeignAgent = HttpContext.Session.GetObject<ForegnAgentDto>("ForeignAgent");
                var twoDigitFromName = userForeignAgent.ForeignAgentName.ToUpper().Substring(0, 2);

                //get last cv reference number for & make plus one into the number
                string refNo = await GetCVRefNumber(userForeignAgent, twoDigitFromName);
                AddAddNewForeignCvRequest model = new() { cv = new CVDto() { CvReferenceNumber = refNo }, foreignAgentId = userForeignAgent.Id, foreignAgentUserId = LoggedInuser.Id };
                return View(model);
            }

            //update exist cv
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ForeignAgentAddNewCV(AddAddNewForeignCvRequest model,
                                                        IFormFile personalphoto, IFormFile posterphoto, IFormFile passportphoto)
        {
            if (model.cv.Id == null)
            {
                await addNewCv(model, personalphoto, posterphoto, passportphoto);
            }
            await GetDropDownList();
            return View(model);
        }

        async Task addNewCv(AddAddNewForeignCvRequest model, IFormFile personalphoto, IFormFile posterphoto, IFormFile passportphoto)
        {
            //add cv status
            if (personalphoto == null || posterphoto == null || passportphoto == null || model.cv.CandidateNameEnglish == null)
                model.cvStatusId = (int)cvStatus.InComplete;
            else model.cvStatusId = (int)cvStatus.Free;

            //add cv attachment
            var attachmentsList = await SaveAttachments(personalphoto, posterphoto, passportphoto, model.foreignAgentUserId);
            if (attachmentsList.Count > 0)
                model.cvAttachments = attachmentsList;

            model.cv.CreatedById = model.foreignAgentUserId;
            model.cv.CreatedDate = DateTime.Now;

            var command = new AddAddNewForeignCvRequest()
            {
                cv = model.cv,
                cvAttachments = attachmentsList,
                foreignAgentId = model.foreignAgentId,
                foreignAgentUserId = model.foreignAgentUserId,
                cvStatusId = model.cvStatusId,
                previousEmployment = model.previousEmployment
            };

            var newCv = await _mediator.Send(command);
            model.cv.Id = newCv;
        }

        private async Task<string> GetCVRefNumber(ForegnAgentDto userForeignAgent, string twoDigitFromName)
        {
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgent.Id };
            var ForeignAgentCvList = await _mediator.Send(query);
            string refNo = null;
            if (ForeignAgentCvList.Count > 0)
            {
                var lastCvRefNo = ForeignAgentCvList.OrderBy(r => r.CV.Id).Last().CV.CvReferenceNumber;
                var removeTwoDigit = lastCvRefNo.Remove(0, 2);
                refNo = twoDigitFromName + (removeTwoDigit + 1);
            }
            else
            {
                refNo = twoDigitFromName + "0000100";
            }

            return refNo;
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

        static async Task<List<Attachment>> SaveAttachments(IFormFile personalphoto, IFormFile posterphoto, IFormFile passportphoto, string foreignAgentUserId)
        {
            List<Attachment> attachments = new();
            
            if (personalphoto != null)
                {
                    string path = Path.Combine("wwwroot/ForeignAttachment/");
                    //create folder if not exist
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    FileInfo fileInfo = new FileInfo(personalphoto.FileName);

                    string fileName = personalphoto.FileName.Split(".")[0] + string.Format(@"{0}", Guid.NewGuid()) + fileInfo.Extension;

                    string fileNameWithPath = Path.Combine(path, fileName);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.CreateNew))
                    {
                        await personalphoto.CopyToAsync(stream);
                    }

                    var nameOfFile = fileNameWithPath.Replace("wwwroot", "../..");

                    Attachment attachment = new();
                    attachment.CreatedById = foreignAgentUserId;
                    attachment.CreatedDate = DateTime.Now;
                    attachment.AttachmentTypeId = (int) cvAttachmentType.PersonalPhoto;
                    attachment.Path = nameOfFile;

                    attachments.Add(attachment);
                }

            if (posterphoto != null)
            {
                string path = Path.Combine("wwwroot/ForeignAttachment/");
                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                FileInfo fileInfo = new FileInfo(posterphoto.FileName);

                string fileName = posterphoto.FileName.Split(".")[0] + string.Format(@"{0}", Guid.NewGuid()) + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.CreateNew))
                {
                    await posterphoto.CopyToAsync(stream);
                }

                var nameOfFile = fileNameWithPath.Replace("wwwroot", "../../");

                Attachment attachment = new();
                attachment.CreatedById = foreignAgentUserId;
                attachment.CreatedDate = DateTime.Now;
                attachment.AttachmentTypeId = (int)cvAttachmentType.PosterPhoto;
                attachment.Path = nameOfFile;

                attachments.Add(attachment);
            }

            if (passportphoto != null)
            {
                string path = Path.Combine("wwwroot/ForeignAttachment/");
                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                FileInfo fileInfo = new FileInfo(passportphoto.FileName);

                string fileName = passportphoto.FileName.Split(".")[0] + string.Format(@"{0}", Guid.NewGuid()) + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.CreateNew))
                {
                    await passportphoto.CopyToAsync(stream);
                }

                var nameOfFile = fileNameWithPath.Replace("wwwroot", "../../");

                Attachment attachment = new();
                attachment.CreatedById = foreignAgentUserId;
                attachment.CreatedDate = DateTime.Now;
                attachment.AttachmentTypeId = (int)cvAttachmentType.PassportCopy;
                attachment.Path = nameOfFile;

                attachments.Add(attachment);
            }

            return attachments;
        }

        #endregion
    }
}
