using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities { }
public class Education : EntityBase
{
    public string EducationEnglish { get; set; }
    public string EducationArabic { get; set; }
    public bool? Status { get; set; }
}

