using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ReportViewerCore
{
    class Report
    {
        public static void Load(LocalReport report, AddAddNewForeignCvRequest model, string splitImageUrl)
        {
            ReportPreviousEmployment[] PreviousEmployment = new ReportPreviousEmployment[model.cvAttachments.Count - 1];
            GetEmployments(model, PreviousEmployment);

            ReportSkills[] skillList = new ReportSkills[model.skillList.Count];
            GetSkills(model, skillList);

            var Img = model.cvAttachments is not null ? model.cvAttachments
                                    .Where(att => att.AttachmentType.TypeName == cvAttachmentType.PersonalPhoto.ToString())
                                    .FirstOrDefault().Path.Split("/")[3] : "";

            var passport = model.cvAttachments is not null ? model.cvAttachments
                                    .Where(att => att.AttachmentType.TypeName == cvAttachmentType.PassportCopy.ToString())
                                    .FirstOrDefault().Path.Split("/")[3] : "";

            var poster = model.cvAttachments is not null ? model.cvAttachments
                                    .Where(att => att.AttachmentType.TypeName == cvAttachmentType.PosterPhoto.ToString())
                                    .FirstOrDefault().Path.Split("/")[3] : "";


            var reportData = new[]
            {
                new ReportItem
                {
                    CvReferenceNumber = model.cv.CvReferenceNumber,
                    CandidateNameEnglish = model.cv.CandidateNameEnglish,
                    CandidateNameArabic = model.cv.CandidateNameArabic,
                    //Designation = model.cv.Designation,
                    CandidateSalary = model.cv.CandidateSalary,
                    ContractPeriod = model.cv.ContractPeriod.ToString(),
                    PassportNumber = model.cv.PassportNumber,
                    EnglishLanguage = (bool)model.cv.EnglishLanguage ? "Yes" : "No",
                    ArabicLanguage = (bool)model.cv.ArabicLanguage ? "Yes" : "No",
                    //Education = model.cv.Education,
                    Nationality = model.cv.Nationality,
                    Religion = model.cv.Religion,
                    DateOfBirth = model.cv.DateOfBirth is not null ?  model.cv.DateOfBirth.Value.ToString("dd/MM/yyyy") : "",
                    martial = model.cv.martial,
                    Gender =  model.cv.Gender.ToString() == Gender.Male.ToString() ? Gender.Male.ToString() : Gender.Female.ToString(),
                    Weight = model.cv.Weight.ToString(),
                    Height = model.cv.Height.ToString(),
                    Age = model.cv.Age.ToString(),
                    PassportPath = passport,
                    PersonalImgPath = Img
                }
            };

            var parameters = new[] { new ReportParameter("Title", $"{model.cv.CandidateNameEnglish}"),
                  new ReportParameter("img", $"{splitImageUrl}ForeignAttachment/{reportData[0].PersonalImgPath}"),
            new ReportParameter("passportImg", $"{splitImageUrl}ForeignAttachment/{reportData[0].PassportPath}"),
            new ReportParameter("postertImg", $"{splitImageUrl}ForeignAttachment/{poster}")};

            using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("App.Web.Reports.Report.rdlc");
            report.LoadReportDefinition(rs);

            report.DataSources.Add(new ReportDataSource("Items", reportData));
            report.DataSources.Add(new ReportDataSource("Previous", PreviousEmployment));
            report.DataSources.Add(new ReportDataSource("Skills", skillList));

            report.EnableExternalImages = true;
            report.SetParameters(parameters);
        }

        private static void GetEmployments(AddAddNewForeignCvRequest model, ReportPreviousEmployment[] PreviousEmployment)
        {
            if (model.previousEmployment.Count > 0)
            {
                for (int i = 0; i < model.previousEmployment.Count; i++)
                {
                    var ReportPreviousEmployment = new ReportPreviousEmployment();
                    //ReportPreviousEmployment.Position = model.previousEmployment[i].Position;
                    ReportPreviousEmployment.Period = model.previousEmployment[i].Period.ToString();
                    ReportPreviousEmployment.CountryOfEmployment = model.previousEmployment[i].CountryOfEmployment.NameEnglish;
                    ReportPreviousEmployment.CountryOfEmploymentArabic = model.previousEmployment[i].CountryOfEmployment.NameArabic;

                    PreviousEmployment[i] = ReportPreviousEmployment;
                }
            }
        }

        private static void GetSkills(AddAddNewForeignCvRequest model, ReportSkills[] skillListt)
        {
            if (model.skillList.Count > 0)
            {
                for (int i = 0; i < model.skillList.Count; i++)
                {
                    var skills = new ReportSkills();
                    skills.Text = model.skillList[i].Text;
                    skills.Value = model.skillList[i].Value;
                    skillListt[i] = skills;

                }
            }
        }
    }
}
