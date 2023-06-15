
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities { }

public class Country : EntityBase
{
    public string NameEnglish { get; set; }
    public string NameArabic { get; set; }
    public bool? Status { get; set; }
}

