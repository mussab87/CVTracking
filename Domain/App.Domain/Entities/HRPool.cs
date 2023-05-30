
namespace App.Domain.Entities { }
public class HRPool : EntityBase
{
    public ForeignAgent ForeignAgent { get; set; }
    public CV CV { get; set; }
    public CVStatus CVStatus { get; set; }
}

