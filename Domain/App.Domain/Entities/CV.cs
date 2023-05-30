
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class CV : EntityBase
{
    public string CvReferenceNumber { get; set; }
    public string CandidateSalary { get; set; }
    public int? ContractPeriod { get; set; }

    public string PassportNumber { get; set; }
    public DateTime? PassportDateOfIssue { get; set; }
    public DateTime? PassportDateOfExpiry { get; set; }
    public string PlaceOfIssue { get; set; }

    public bool? EnglishLanguage { get; set; }
    public bool? ArabicLanguage { get; set; }

    public int? Education { get; set; }

    public int? NationalityId { get; set; }
    [ForeignKey("NationalityId")]
    public Country Nationality { get; set; }
    public string Religion { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int? PlaceOfBirthId { get; set; }
    [ForeignKey("PlaceOfBirthId")]
    public City PlaceOfBirth { get; set; }
    public int? MartialStatus { get; set; }
    public string NoOfChildren { get; set; }
    public int? Weight { get; set; }
    public int? Height { get; set; }
    public int? Age { get; set; }
    public string PhoneNumber { get; set; }
    public string EmergencyContact { get; set; }
}

