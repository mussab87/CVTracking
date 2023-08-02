
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

    public bool? SendByWhatapp { get; set; }
    public DateTime? SendByWhatappDateTime { get; set; }

    public bool? IsCancel { get; set; }
    public int? CancelReasonId { get; set; }
    [ForeignKey("CancelReasonId")]
    public CancelReason CancelReason { get; set; }
    public string CancelNotes { get; set; }

    public string? CanceledById { get; set; }
    [ForeignKey("CanceledById")]
    public ApplicationUser CanceledBy { get; set; }
    public DateTime? CancelDateTime { get; set; }
}

