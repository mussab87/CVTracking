
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.CandidateSkills { }
public class CVCandidateSkillsRepository : RepositoryBase<CVCandidateSkills>, ICVCandidateSkillsRepository
{
    public CVCandidateSkillsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

}
