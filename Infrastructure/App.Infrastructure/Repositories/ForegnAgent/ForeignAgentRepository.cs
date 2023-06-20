using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.ForegnAgent { }

public class ForeignAgentRepository : RepositoryBase<ForeignAgent>, IForeignAgentRepository
{
    public ForeignAgentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddRootCompanyForeignAgent(RootCompanyForeignAgent rootForeignAgent)
    {
        await _dbContext.RootCompanyForeignAgents.AddAsync(rootForeignAgent);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<HRPool>> GetAllForeignAgentCvList(int ForeignAgentId)
    {
        var query = await _dbContext.HRPools
                    .Include(c => c.ForeignAgent)
                    .Include(c => c.CV)
                    .Include(c => c.CV.Nationality)
                    .Include(c => c.CV.Religion)
                    .Include(c => c.CV.PlaceOfBirth)
                    .Include(c => c.CV.MartialStatus)
                    .Include(c => c.CVStatus)
                    .Include(c => c.LocalAgent)
                    .Where(c => c.ForeignAgent.Id == ForeignAgentId).ToListAsync();

        return query;
    }

    public async Task<List<ForeignAgent>> GetForeignAgentByRootCompanyId(int rootCompanyId)
    {
        var query = await _dbContext.RootCompanyForeignAgents
                    .Where(u => u.RootCompanyId == rootCompanyId)
                    .Include(u => u.ForeignAgent)
                    .Include(u => u.ForeignAgent.ForeignAgentCountryCity)
                    .Include(u => u.ForeignAgent.ForeignAgentCountryCity.CountryCity)
                    .Select(u => u.ForeignAgent)
                    .ToListAsync();

        return query;
    }
}

