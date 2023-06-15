
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.CandidateSkills { }
public class CandidateSkillsRepository : RepositoryBase<CandidateSkills>, ICandidateSkillsRepository
{
    public CandidateSkillsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddCVCandidateSkills(CV cv, int[] skils, string foreugnUserId)
    {
        List<CVCandidateSkills> skills = new();
        for (int i = 0; i < skils.Length; i++)
        {
            CVCandidateSkills cvskill = new()
            {
                CVId = cv.Id,
                CandidateSkillsId = skils[i],
                CreatedById = foreugnUserId,
                CreatedDate = DateTime.Now
            };
            skills.Add(cvskill);
        }
        if (skills.Count > 0)
            await _dbContext.CVCandidateSkils.AddRangeAsync(skills);
        _dbContext.SaveChanges();
    }

    public async Task<List<CVCandidateSkills>> GetCVCandidateSkills(int cvId)
    {
        return await _dbContext.CVCandidateSkils
                    .Include(C => C.CV)
                    .Include(C => C.CandidateSkills)
                    .Where(c => c.CVId == cvId).ToListAsync();
    }
}
