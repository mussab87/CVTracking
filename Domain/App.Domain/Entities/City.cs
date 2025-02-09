﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class City : EntityBase
{
    public string NameEnglish { get; set; }
    public string NameArabic { get; set; }
    public bool? Status { get; set; }
    public int? CountryCityId { get; set; }
    [ForeignKey("CountryCityId")]
    public Country CountryCity { get; set; }
}

