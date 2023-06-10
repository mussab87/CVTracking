using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities { }
public class Religion : EntityBase
{
    public string ReligionEnglish { get; set; }
    public string ReligionArabic { get; set; }
    public bool? Status { get; set; }
}

