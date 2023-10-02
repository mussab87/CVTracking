using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.ForegnAgent { }

public class CVRepository : RepositoryBase<CV>, ICVRepository
{
    public CVRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddHRPool(CV cv, ForeignAgent foreignAgent, CVStatus status, string userId)
    {
        HRPool hRPool = new HRPool()
        {
            CV = cv,
            ForeignAgent = foreignAgent,
            CVStatus = status,
            CreatedById = userId,
            CreatedDate = DateTime.Now
        };
        await _dbContext.HRPools.AddAsync(hRPool);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<CVAttachment>> GetCvAttachmentByCvId(int cvId)
    {
        var query = await _dbContext.CVAttachments
                    .Include(c => c.CV)
                    .Include(c => c.Attachment)
                    .Include(c => c.Attachment.AttachmentType)
                    .Where(c => c.CVId == cvId).ToListAsync();

        return query;
    }

    public async Task<List<PreviousEmployment>> GetCvPreviousEmploymentByCvId(int cvId)
    {
        var query = await _dbContext.PreviousEmployments
                    .Include(c => c.CV)
                    .Include(c => c.Position)
                    .Where(p => p.CV.Id == cvId).ToListAsync();

        return query;
    }

    public async Task<HRPool> GetForeignCvById(int ForeignAgentcvId)
    {
        var query = await _dbContext.HRPools
                    .Include(c => c.ForeignAgent)
                    .Include(c => c.CV)
                    .Include(c => c.CV.Nationality)
                    .Include(c => c.CV.Religion)
                    .Include(c => c.CV.PlaceOfBirth)
                    .Include(c => c.CV.MartialStatus)
                    .Include(c => c.CVStatus)
                    .Include(c => c.CV.Designation)
                    .Include(c => c.CV.Education)
                    .Where(c => c.CV.Id == ForeignAgentcvId).FirstOrDefaultAsync();

        return query;
    }
}

