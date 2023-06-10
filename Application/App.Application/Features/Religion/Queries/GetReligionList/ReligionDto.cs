
using System.Diagnostics.Metrics;

namespace App.Application.Features.Religion.Queries.GetReligionList { }

public class ReligionDto
{
    public int Id { get; protected set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public string ReligionEnglish { get; set; }
    public string ReligionArabic { get; set; }
    public bool? Status { get; set; }
}

