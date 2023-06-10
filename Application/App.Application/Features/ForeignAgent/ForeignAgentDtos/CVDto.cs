using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.ForeignAgent.ForeignAgentDtos { }

public class CVDto
{
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    //done
    [Display(Name = "CV Reference Number")]
    public string CvReferenceNumber { get; set; }

    //done
    [Display(Name = "Name English")]
    public string CandidateNameEnglish { get; set; }

    //done
    [Display(Name = "Name Arabic")]
    public string CandidateNameArabic { get; set; }

    //done
    [Display(Name = "Designation")]
    public string Designation { get; set; }

    //done
    [Display(Name = "Salary")]
    public string CandidateSalary { get; set; }

    //done
    [Display(Name = "Contract Period")]
    public int? ContractPeriod { get; set; }

    //done
    [Display(Name = "Passport Number")]
    public string PassportNumber { get; set; }

    //done
    [Display(Name = "Passport Date Of Issue")]
    public DateTime? PassportDateOfIssue { get; set; }

    //done
    [Display(Name = "Passport Date Of Expiry")]
    public DateTime? PassportDateOfExpiry { get; set; }

    //done
    [Display(Name = "Passport Place Of Issue")]
    public string PlaceOfIssue { get; set; }

    //done
    [Display(Name = "English")]
    public bool? EnglishLanguage { get; set; }

    //done
    [Display(Name = "Arabic")]
    public bool? ArabicLanguage { get; set; }

    //done
    [Display(Name = "Education")]
    public int? Education { get; set; }

    //done
    [Display(Name = "Nationality")]
    public int? NationalityId { get; set; }

    //done
    [Display(Name = "Religion")]
    public int? ReligionId { get; set; }

    //done
    [Display(Name = "Date Of Birth")]
    public DateTime? DateOfBirth { get; set; }

    //done
    [Display(Name = "Place Of Birth")]
    public int? PlaceOfBirthId { get; set; }

    //done
    [Display(Name = "Martial Status")]
    public int? MartialStatusId { get; set; }

    //done
    public int Gender { get; set; }

    //done
    [Display(Name = "No Of Children")]
    public string NoOfChildren { get; set; }

    //done
    [Display(Name = "Weight")]
    public int? Weight { get; set; }

    //done
    [Display(Name = "Height")]
    public int? Height { get; set; }

    //done
    [Display(Name = "Age")]
    public int? Age { get; set; }

    //done
    [Display(Name = "PhoneNumber")]
    public string PhoneNumber { get; set; }

    //done
    [Display(Name = "EmergencyContact")]
    public string EmergencyContact { get; set; }
}

