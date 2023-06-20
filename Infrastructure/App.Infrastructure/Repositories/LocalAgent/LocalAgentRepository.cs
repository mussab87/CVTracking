using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.LocalAgent { }

public class LocalAgentRepository : RepositoryBase<LocalAgent>, ILocalAgentRepository
{
    public LocalAgentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddRootCompanyLocalAgent(RootCompanyLocalAgent rootLocalAgent)
    {
        await _dbContext.RootCompanyLocalAgents.AddAsync(rootLocalAgent);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<HRPool>> GetAllLocalAgentCvList(int LocalAgentId)
    {
        var query = await _dbContext.HRPools
                    .Include(c => c.LocalAgent)
                    .Include(c => c.CV)
                    .Include(c => c.CV.Nationality)
                    .Include(c => c.CV.Religion)
                    .Include(c => c.CV.PlaceOfBirth)
                    .Include(c => c.CV.MartialStatus)
                    .Include(c => c.CVStatus)
                    .Include(c => c.ForeignAgent)
                    .Where(c => c.LocalAgentId == LocalAgentId).ToListAsync();

        return query;
    }

    public async Task<List<LocalAgent>> GetLocalAgentByRootCompanyId(int rootCompanyId)
    {
        var query = await _dbContext.RootCompanyLocalAgents
                    .Where(u => u.RootCompanyId == rootCompanyId)
                    .Include(u => u.LocalAgent)
                    .Include(u => u.LocalAgent.LocalAgentCountryCity)
                    .Include(u => u.LocalAgent.LocalAgentCountryCity.CountryCity)
                    .Select(u => u.LocalAgent)
                    .ToListAsync();

        return query;
    }
}

