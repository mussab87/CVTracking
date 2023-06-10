using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities { }
public class MartialStatus : EntityBase
{
    public string MartialStatusEnglish { get; set; }
    public string MartialStatusArabic { get; set; }
    public bool? Status { get; set; }
}

