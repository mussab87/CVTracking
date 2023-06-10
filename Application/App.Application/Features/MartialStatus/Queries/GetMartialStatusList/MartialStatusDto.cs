
using System.Diagnostics.Metrics;

namespace App.Application.Features.MartialStatus.Queries.GetMartialStatusList { }

public class MartialStatusDto
{
    public int Id { get; protected set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public string MartialStatusEnglish { get; set; }
    public string MartialStatusArabic { get; set; }
    public bool? Status { get; set; }
}

