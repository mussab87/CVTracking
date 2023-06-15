
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class CandidateSkills : EntityBase
{
    public string SkillEnglish { get; set; }
    public string SkillArabic { get; set; }
    public bool? Status { get; set; }
}

