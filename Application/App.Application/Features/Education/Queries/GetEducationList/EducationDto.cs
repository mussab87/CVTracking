
using System.Diagnostics.Metrics;

namespace App.Application.Features.Education.Queries.GetEducationList { }

public class EducationDto
{
    public int Id { get; protected set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public string EducationEnglish { get; set; }
    public string EducationArabic { get; set; }
    public bool? Status { get; set; }
}

