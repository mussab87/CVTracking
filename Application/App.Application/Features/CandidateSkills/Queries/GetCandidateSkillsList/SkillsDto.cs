
using System.Diagnostics.Metrics;

namespace App.Application.Features.CandidateSkills.Queries.GetCandidateSkillsList { }

public class SkillsDto
{
    public int Id { get; set; }
    public string? CreatedById { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public string SkillEnglish { get; set; }
    public string SkillArabic { get; set; }
    public bool? Status { get; set; }
}

