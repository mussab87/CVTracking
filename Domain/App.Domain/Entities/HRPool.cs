
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }
public class HRPool : EntityBase
{
    public ForeignAgent ForeignAgent { get; set; }
    public CV CV { get; set; }
    public CVStatus CVStatus { get; set; }
    public int? LocalAgentId { get; set; }
    [ForeignKey("LocalAgentId")]
    public LocalAgent LocalAgent { get; set; }
    public DateTime? SendToLocalDateTime { get; set; }
}

