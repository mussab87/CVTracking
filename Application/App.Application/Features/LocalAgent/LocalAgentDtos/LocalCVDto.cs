using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.LocalAgent.LocalAgentDtos { }

public class LocalCVDto
{
    public int? Id { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    //done
    [Display(Name = "CV Reference Number")]
    public string CvReferenceNumber { get; set; }

    //done
    [Display(Name = "Name English")]
    [Required(ErrorMessage = "Name English is Required")]
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
    [Required(ErrorMessage = "Passport Number is Required")]
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
    [Required(ErrorMessage = "Date Of Birth is Required")]
    public DateTime? DateOfBirth { get; set; }

    //done
    [Display(Name = "Place Of Birth")]
    [Required(ErrorMessage = "Place Of Birth is Required")]
    public int? PlaceOfBirthId { get; set; }

    //done
    [Display(Name = "Martial Status")]
    [Required(ErrorMessage = "Martial Status is Required")]
    public int? MartialStatusId { get; set; }

    //done
    [Required(ErrorMessage = "Gender is Required")]
    public int Gender { get; set; }

    //done
    [Display(Name = "No Of Children")]
    [Required(ErrorMessage = "No Of Children is Required")]
    public string NoOfChildren { get; set; }

    //done
    [Display(Name = "Weight")]
    [Required(ErrorMessage = "Weight Field is Required")]
    public int? Weight { get; set; }

    //done
    [Display(Name = "Height")]
    [Required(ErrorMessage = "Height Field is Required")]
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

