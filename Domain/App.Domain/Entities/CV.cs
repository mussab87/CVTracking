﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class CV : EntityBase
{
    public string CvReferenceNumber { get; set; }
    public string CandidateNameEnglish { get; set; }
    public string CandidateNameArabic { get; set; }

    public int? DesignationId { get; set; }
    [ForeignKey("DesignationId")]
    public Designation Designation { get; set; }

    //public string Designation { get; set; }
    public string CandidateSalary { get; set; }
    public int? ContractPeriod { get; set; }

    public string PassportNumber { get; set; }
    public DateTime? PassportDateOfIssue { get; set; }
    public DateTime? PassportDateOfExpiry { get; set; }
    public int? PlaceOfIssueId { get; set; }
    [ForeignKey("PlaceOfIssueId")]
    public City PlaceOfIssue { get; set; }

    public bool? EnglishLanguage { get; set; }
    public bool? ArabicLanguage { get; set; }

    //public string Education { get; set; }
    public int? EducationId { get; set; }
    [ForeignKey("EducationId")]
    public Education Education { get; set; }

    public int? NationalityId { get; set; }
    [ForeignKey("NationalityId")]
    public Country Nationality { get; set; }
    public int? ReligionId { get; set; }
    [ForeignKey("ReligionId")]
    public Religion Religion { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int? PlaceOfBirthId { get; set; }
    [ForeignKey("PlaceOfBirthId")]
    public City PlaceOfBirth { get; set; }
    public int? MartialStatusId { get; set; }
    [ForeignKey("MartialStatusId")]
    public MartialStatus MartialStatus { get; set; }
    public int Gender { get; set; }
    public string NoOfChildren { get; set; }
    public int? Weight { get; set; }
    public int? Height { get; set; }
    public int? Age { get; set; }
    public string PhoneNumber { get; set; }
    public string EmergencyContact { get; set; }

}

