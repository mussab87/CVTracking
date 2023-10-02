using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities { }
public class Designation : EntityBase
{
    public string DesignationEnglish { get; set; }
    public string DesignationArabic { get; set; }
    public bool? Status { get; set; }
}

