using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities { }
public class MartialStatus : EntityBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; protected set; }
    public string MartialStatusEnglish { get; set; }
    public string MartialStatusArabic { get; set; }
    public bool? Status { get; set; }
}

