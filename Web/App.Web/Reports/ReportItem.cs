using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReportViewerCore
{
    public class ReportItem
    {
        public string CvReferenceNumber { get; set; }
        public string CandidateNameEnglish { get; set; }
        public string CandidateNameArabic { get; set; }
        public string Designation { get; set; }
        public string DesignationAr { get; set; }
        public string CandidateSalary { get; set; }
        public string ContractPeriod { get; set; }
        public string PassportNumber { get; set; }
        public string EnglishLanguage { get; set; }
        public string ArabicLanguage { get; set; }
        public string Education { get; set; }
        public string EducationAr { get; set; }
        public string Nationality { get; set; }
        public string NationalityAr { get; set; }
        public string Religion { get; set; }
        public string ReligionAr { get; set; }
        public string DateOfBirth { get; set; }
        public string martial { get; set; }
        public string martialAr { get; set; }
        public string Gender { get; set; }
        public string GenderAr { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Age { get; set; }

        public string PassportPath { get; set; }
        public string PersonalImgPath { get; set; }
    }
}
