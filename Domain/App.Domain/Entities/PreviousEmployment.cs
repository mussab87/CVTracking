
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class PreviousEmployment : EntityBase
{
    public int Period { get; set; }
    public int? CountryOfEmploymentId { get; set; }
    [ForeignKey("CountryOfEmploymentId")]
    public Country CountryOfEmployment { get; set; }
    //public string Position { get; set; }

    public int? PositionId { get; set; }
    [ForeignKey("PositionId")]
    public Designation Position { get; set; }
    public CV CV { get; set; }
}

