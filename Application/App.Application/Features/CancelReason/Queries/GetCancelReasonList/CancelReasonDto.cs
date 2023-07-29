
using System.Diagnostics.Metrics;

namespace App.Application.Features.CancelReason.Queries.GetCancelReasonList { }

public class CancelReasonDto
{
    public int Id { get; protected set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public string CancelReasonEnglish { get; set; }
    public string CancelReasonArabic { get; set; }
    public bool? Status { get; set; }
}

