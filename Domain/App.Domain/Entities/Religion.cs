using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities { }
public class Religion : EntityBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; protected set; }
    public string ReligionEnglish { get; set; }
    public string ReligionArabic { get; set; }
    public bool? Status { get; set; }
}

