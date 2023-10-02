
using System.Diagnostics.Metrics;

namespace App.Application.Features.Designation.Queries.GetDesignationList { }

public class DesignationDto
{
    public int Id { get; protected set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public string DesignationEnglish { get; set; }
    public string DesignationArabic { get; set; }
    public bool? Status { get; set; }
}

