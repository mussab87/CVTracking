using App.Application.Features.RootCompany.Queries.GetRootCompanyByUserId;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)LoggedInuser.ForeignAgentId };
            var ForeignAgentCvList = await _mediator.Send(query);

            var ForeignAgentCount = new FoerignAgentCountDto()
            {
                CvCount = ForeignAgentCvList.Count(),
                PostToAdminCount = ForeignAgentCvList.Where(s => s.CVStatus.StatusNo == (int)cvStatus.PostToAdmin).Count(),
                SelectedCvCount = ForeignAgentCvList.Where(s => s.CVStatus.StatusNo == (int)cvStatus.Uploaded).Count()
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
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("ForeignAgent");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList.Where(s => s.CVStatus.StatusNo == (int)cvStatus.Uploaded));
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentPostToAdminApplicants")]
        public async Task<IActionResult> ForeignAgentPostToAdminApplicants()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("ForeignAgent");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList.Where(s => s.CVStatus.StatusNo == (int)cvStatus.PostToAdmin));
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentInCompleteCV")]
        public async Task<IActionResult> ForeignAgentInCompleteCV()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("ForeignAgent");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList.Where(s => s.CVStatus.StatusNo == (int)cvStatus.InComplete));
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentBackoutCV")]
        public async Task<IActionResult> ForeignAgentBackoutCV()
        {
            var userRootCompanyId = HttpContext.Session.GetObject<RootCompanyDto>("RootCompany").Id;
            var userForeignAgentId = HttpContext.Session.GetObject<ForegnAgentDto>("ForeignAgent");

            //get all CV for the ForeignAgent
            var query = new GetAllCvListQuery() { ForeignAgentId = (int)userForeignAgentId.Id };
            var ForeignAgentCvList = await _mediator.Send(query);

            return View(ForeignAgentCvList.Where(s => s.CVStatus.StatusNo == (int)cvStatus.Backout));
        }

        [HttpGet]
        [Authorize("ForeignAgent-ForeignAgentAddNewCV")]
        public async Task<IActionResult> ForeignAgentAddNewCV(int id)
        {


            var LoggedInuser = await ShardFunctions.GetLoggedInUserAsync(_userManager, User);
            //configure reference number - first 2 digit from ForeignAgent name + 0000100
            var userForeignAgent = HttpContext.Session.GetObject<ForegnAgentDto>("ForeignAgent");

            //add new cv
            if (id == 0)
            {
                var twoDigitFromName = userForeignAgent.ForeignAgentName.ToUpper().Substring(0, 2);

                //get last cv reference number for & make plus one into the number
                string refNo = await GetCVRefNumber(userForeignAgent, twoDigitFromName);
                AddAddNewForeignCvRequest model = new()
                {
                    cv = new CVDto()
                    {
                        CvReferenceNumber = refNo
                    },
                    foreignAgentId = userForeignAgent.Id,
                    foreignAgentUserId = LoggedInuser.Id
                };
                await GetDropDownList(model);
                return View(model);
            }

            //get exist cv info by CVId
            var queryGetCVById = new GetForeignCvByIdQuery() { cvId = id };
            var GetCVById = await _mediator.Send(queryGetCVById);

            var existCvAttachments = await getCVAttachments(GetCVById);
            AddAddNewForeignCvRequest model2 = FillExistForeignCv(LoggedInuser, userForeignAgent, GetCVById, existCvAttachments);

            //ViewBag.candidateSkills = model2.Skills;
            await GetDropDownList(model2);
            return View(model2);
        }

        [HttpPost]
        public async Task<IActionResult> ForeignAgentAddNewCV(AddAddNewForeignCvRequest model,
                                                        IFormFile personalphoto, IFormFile posterphoto, IFormFile passportphoto, int[] states)
        {

            if (model.cv.Id == null)
            {
                //check cv fields first before going to save 
                //if (await CheckCvBeforeSave(model, personalphoto, posterphoto, passportphoto, states, true) == false)
                //{
                //    ModelState.AddModelError("CustomError", "You must enter all required fields before click on save");
                //    //await GetDropDownList(model);
                //    //ViewBag.error = "yes";
                //    //return View(model);
                //}

                await addNewCv(model, personalphoto, posterphoto, passportphoto, true, states);
                await GetDropDownList(model);
                TempData["Message"] = 1;
                return RedirectToAction("ForeignAgentAddNewCV", new { id = model.cv.Id });
            }

            //update exist cv data
            //check cv fields first before going to save 
            //if (await CheckCvBeforeSave(model, personalphoto, posterphoto, passportphoto, states, false) == false)
            //{
            //    ModelState.AddModelError("CustomError", "You must enter all required fields before click on save");
            //    //await GetDropDownList(model);
            //    //ViewBag.error = "yes";
            //    //return View(model);
            //}

            await addNewCv(model, personalphoto, posterphoto, passportphoto, false, states);

            await GetDropDownList(model);
            TempData["Message"] = 2;
            return RedirectToAction("ForeignAgentAddNewCV", new { id = model.cv.Id });
        }

        private AddAddNewForeignCvRequest FillExistForeignCv(ApplicationUser LoggedInuser, ForegnAgentDto userForeignAgent, ForeignAgentHRPoolDto GetCVById, List<Attachment> existCvAttachments)
        {

            return new()
            {
                cv = _mapper.Map<CVDto>(GetCVById.CV),
                cvAttachments = existCvAttachments,
                cvHRpool = GetCVById.cvHRpool,
                previousEmployment = GetCVById.previousEmployment.Count > 0 ? GetCVById.previousEmployment : null,
                cvStatusId = GetCVById.CVStatus.Id,
                foreignAgentId = userForeignAgent.Id,
                foreignAgentUserId = LoggedInuser.Id,
                HRPoolId = GetCVById.cvHRpool.Id,
                Skills = GetCVById.Skills
            };
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
        async Task addNewCv(AddAddNewForeignCvRequest model, IFormFile personalphoto, IFormFile posterphoto, IFormFile passportphoto, bool actionType, int[] skills)
        {
            //add cv status
            AddCVStatus(model, personalphoto, posterphoto, passportphoto, skills, actionType);

            //add cv attachment
            List<Attachment> attachmentsList = new();
            if (personalphoto is not null || posterphoto is not null || passportphoto is not null)
            {
                attachmentsList = await SaveAttachments(personalphoto, posterphoto, passportphoto, model.foreignAgentUserId, model);
                if (attachmentsList.Count > 0)
                    model.cvAttachments = attachmentsList;
            }

            model.cv.CreatedById = model.foreignAgentUserId;
            model.cv.CreatedDate = DateTime.Now;

            if (actionType)
            {
                var command = new AddAddNewForeignCvRequest()
                {
                    cv = model.cv,
                    cvAttachments = attachmentsList,
                    foreignAgentId = model.foreignAgentId,
                    foreignAgentUserId = model.foreignAgentUserId,
                    cvStatusId = model.cvStatusId,
                    previousEmployment = model.previousEmployment,
                    personalImg = model.personalImg,
                    posterImg = model.posterImg,
                    passportImg = model.passportImg,
                    Skills = skills
                };
                var newCv = await _mediator.Send(command);
                model.cv.Id = newCv;

            }
            else
            {
                var command = new UpdateForeignCvRequest()
                {
                    cv = model.cv,
                    cvAttachments = attachmentsList,
                    foreignAgentId = model.foreignAgentId,
                    foreignAgentUserId = model.foreignAgentUserId,
                    cvStatusId = model.cvStatusId,
                    previousEmployment = model.previousEmployment,
                    HRPoolId = model.HRPoolId,
                    personalImg = model.personalImg,
                    posterImg = model.posterImg,
                    passportImg = model.passportImg,
                    Skills = skills
                };
                var newCv = await _mediator.Send(command);
            }


        }

        static void AddCVStatus(AddAddNewForeignCvRequest model, IFormFile personalphoto, IFormFile posterphoto, IFormFile passportphoto, int[] skills, bool actionType)
        {
            if (actionType)
            {
                if (model.cv.NoOfChildren is null)
                    model.cv.NoOfChildren = "0";

                if (personalphoto == null ||
                            posterphoto == null ||
                            passportphoto == null ||
                            model.cv.CandidateNameEnglish == null ||
                            model.cv.DateOfBirth == null ||
                            //model.cv.PlaceOfBirthId == null ||
                            model.cv.MartialStatusId == null ||
                            model.cv.NoOfChildren == null ||
                            model.cv.Weight == null ||
                            model.cv.Height == null ||
                            model.cv.PassportNumber == null ||
                            skills.Length < 0 ||
                            model.previousEmployment[0].Position == null ||
                            model.previousEmployment[0].Period == 0 ||
                            model.previousEmployment[0].CountryOfEmploymentId == null)
                    model.cvStatusId = (int)cvStatus.InComplete;
                else model.cvStatusId = (int)cvStatus.Free;
            }
            else
            {
                if (model.cv.NoOfChildren is null)
                    model.cv.NoOfChildren = "0";

                if (model.personalImg == null ||
                            model.posterImg == null ||
                            model.passportImg == null ||
                            model.cv.CandidateNameEnglish == null ||
                            model.cv.DateOfBirth == null ||
                            //model.cv.PlaceOfBirthId == null ||
                            model.cv.MartialStatusId == null ||
                            model.cv.NoOfChildren == null ||
                            model.cv.Weight == null ||
                            model.cv.Height == null ||
                            model.cv.PassportNumber == null ||
                            skills.Length < 0 ||
                            model.previousEmployment[0].Position == null ||
                            model.previousEmployment[0].Period == 0 ||
                            model.previousEmployment[0].CountryOfEmploymentId == null)
                    model.cvStatusId = (int)cvStatus.InComplete;
                else model.cvStatusId = (int)cvStatus.Free;
            }

        }

        private async Task<bool> CheckCvBeforeSave(AddAddNewForeignCvRequest model, IFormFile personalphoto, IFormFile posterphoto, IFormFile passportphoto, int[] skills, bool AddNewUpdatetype)
        {
            if (AddNewUpdatetype)
            {
                if (personalphoto == null ||
                            posterphoto == null ||
                            passportphoto == null ||
                            model.cv.CandidateNameEnglish == null ||
                            model.cv.DateOfBirth == null ||
                            //model.cv.PlaceOfBirthId == null ||
                            model.cv.MartialStatusId == null ||
                            model.cv.NoOfChildren == null ||
                            model.cv.Weight == null ||
                            model.cv.Height == null ||
                            model.cv.PassportNumber == null ||
                            skills.Length < 0 ||
                            model.previousEmployment[0].Position == null ||
                            model.previousEmployment[0].Period == 0 ||
                            model.previousEmployment[0].CountryOfEmploymentId == null)
                    return false;
                else return true;
            }
            else
            {
                if (model.personalImg == null ||
                            model.posterImg == null ||
                            model.passportImg == null ||
                            model.cv.CandidateNameEnglish == null ||
                            model.cv.DateOfBirth == null ||
                            //model.cv.PlaceOfBirthId == null ||
                            model.cv.MartialStatusId == null ||
                            model.cv.NoOfChildren == null ||
                            model.cv.Weight == null ||
                            model.cv.Height == null ||
                            model.cv.PassportNumber == null ||
                            skills.Length < 0 ||
                            model.previousEmployment[0].Position == null ||
                            model.previousEmployment[0].Period == 0 ||
                            model.previousEmployment[0].CountryOfEmploymentId == null)
                    return false;
                else return true;
            }

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
                refNo = twoDigitFromName + "0000" + (Convert.ToInt64(removeTwoDigit) + 1).ToString();
            }
            else
            {
                refNo = twoDigitFromName + "0000100";
            }

            return refNo;
        }

        async Task GetDropDownList(AddAddNewForeignCvRequest model = null)
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

            //Skills
            var getSkills = new GetCandidateSkillsListQuery();
            var Skills = await _mediator.Send(getSkills);

            //fill candidate skills
            if (Skills is not null && Skills.Count > 0)
            {
                if (model is not null)
                {
                    model.skillList = new();
                    foreach (var skill in Skills)
                    {
                        if (model.Skills is not null)
                        {
                            var selectedSkills = model.Skills.Where(s => s.Equals(skill.Id)).FirstOrDefault();
                            if (selectedSkills > 0)
                            {
                                var selected = new SkillSelectedDto()
                                {
                                    Text = skill.SkillEnglish,
                                    Value = skill.Id.ToString(),
                                    IsSelected = true
                                };
                                model.skillList.Add(selected);
                            }
                            else
                            {
                                var selected = new SkillSelectedDto()
                                {
                                    Text = skill.SkillEnglish,
                                    Value = skill.Id.ToString(),
                                };
                                model.skillList.Add(selected);
                            }
                        }
                        else
                        {
                            var selected = new SkillSelectedDto()
                            {
                                Text = skill.SkillEnglish,
                                Value = skill.Id.ToString(),
                            };
                            model.skillList.Add(selected);
                        }

                    }
                }
            }

            ViewData["Skills"] = new SelectList(Skills, "Id", "SkillEnglish");
        }

        static async Task<List<Attachment>> SaveAttachments
            (
            IFormFile personalphoto,
            IFormFile posterphoto,
            IFormFile passportphoto,
            string foreignAgentUserId,
            AddAddNewForeignCvRequest model
            )
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
                attachment.AttachmentTypeId = (int)cvAttachmentType.PersonalPhoto;
                attachment.Path = nameOfFile;

                attachments.Add(attachment);
                //flag for update
                model.personalImg = true;
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

                var nameOfFile = fileNameWithPath.Replace("wwwroot", "../..");

                Attachment attachment = new();
                attachment.CreatedById = foreignAgentUserId;
                attachment.CreatedDate = DateTime.Now;
                attachment.AttachmentTypeId = (int)cvAttachmentType.PosterPhoto;
                attachment.Path = nameOfFile;

                attachments.Add(attachment);
                //flag for update
                model.posterImg = true;
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

                var nameOfFile = fileNameWithPath.Replace("wwwroot", "../..");

                Attachment attachment = new();
                attachment.CreatedById = foreignAgentUserId;
                attachment.CreatedDate = DateTime.Now;
                attachment.AttachmentTypeId = (int)cvAttachmentType.PassportCopy;
                attachment.Path = nameOfFile;

                attachments.Add(attachment);
                //flag for update
                model.passportImg = true;
            }

            return attachments;
        }

        [HttpGet]
        [Authorize("ForeignAgent-PostToAdmin")]
        public async Task<IActionResult> PostToAdmin(string cvid)
        {
            try
            {
                if (cvid is null)
                    return Json(new { message = "Error" });

                var LoggedInuser = await _userManager.GetUserAsync(User);

                var CvId = Convert.ToInt32(cvid);

                //update cv status by hrpoolId
                var command = new UpdateForeignCVStatusByHRPoolIdRequest()
                { CVId = CvId, foreignAgentUserId = LoggedInuser.Id };

                var UpdateQuery = await _mediator.Send(command);

                TempData["Message"] = 2;
                return Json(true);
            }
            catch (Exception)
            {
                return Json(new { message = "Error" });
            }

        }

        [HttpPost]
        [Authorize("ForeignAgent-DeleteCV")]
        public async Task<IActionResult> DeleteCV(string cvid, string hrpoolid)
        {
            try
            {
                if (cvid is null)
                    return NotFound(new { message = "Error" });

                var CvId = Convert.ToInt32(cvid);

                //update cv status by hrpoolId
                var command = new DeleteLocalCVRequest()
                { CVId = CvId };

                var UpdateQuery = await _mediator.Send(command);

                TempData["Message"] = 3;
                return RedirectToAction(nameof(ForeignAgentAllCVList));
            }
            catch (Exception)
            {
                return NotFound(new { message = "Error" });
            }

        }

        [HttpGet]
        [Authorize("ForeignAgent-CancelCV")]
        public async Task<IActionResult> CancelCV(string hrpoolid, string cvId, string cancelreason, string notes)
        {
            try
            {
                if (hrpoolid is null)
                    return NotFound(new { message = "Error" });

                var hrpolid = Convert.ToInt32(hrpoolid);
                var CvId = Convert.ToInt32(cvId);
                var cancelReasonId = Convert.ToInt32(cancelreason);

                //update cv status by hrpoolId
                var LoggedInuser = await _userManager.GetUserAsync(User);
                var command = new CancelForeignCVByHRPoolIdRequest()
                {
                    HRPoolId = hrpolid,
                    CVId = CvId,
                    IsCancel = true,
                    CancelReasonId = cancelReasonId,
                    CancelNotes = notes,
                    CancelById = LoggedInuser.Id,
                    CancelDateTime = DateTime.Now
                };

                var UpdateQuery = await _mediator.Send(command);

                TempData["Message"] = 3;
                return RedirectToAction(nameof(ForeignAgentAllCVList));
            }
            catch (Exception)
            {
                return NotFound(new { message = "Error" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> GetCancelReason()
        {
            try
            {
                var query = new GetCancelReasonListQuery();
                var cancelReasonList = await _mediator.Send(query);

                if (cancelReasonList.Any())
                {
                    return Json(cancelReasonList);
                }

                return Json(false);
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion
    }
}
