
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace App.Domain.Entities { }
public class CVCandidateSkills : EntityBase
{
    public int CVId { get; set; }
    public CV CV { get; set; }

    public int CandidateSkillsId { get; set; }
    public CandidateSkills CandidateSkills { get; set; }
}

