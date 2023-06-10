using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.ForegnAgent { }

public class CVRepository : RepositoryBase<CV>, ICVRepository
{
    public CVRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddHRPool(CV cv, ForeignAgent foreignAgent, CVStatus status)
    {
        HRPool hRPool = new HRPool()
        {
            CV = cv,
            ForeignAgent = foreignAgent,
            CVStatus = status
        };
        await _dbContext.HRPools.AddAsync(hRPool);
        await _dbContext.SaveChangesAsync();
    }
}

