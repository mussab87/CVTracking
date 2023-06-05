using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.RootCompany { }
public class RootCompanyRepository : RepositoryBase<RootCompany>, IRootCompanyRepository
{
    public RootCompanyRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<RootCompany> GetRootCompanyByUserId(string userId)
    {
        var query = await _dbContext.RootCompanyUsers
                    .Where(u => u.ApplicationUserId == userId)
                    .Include(u => u.RootCompany).Select(u => u.RootCompany)
                    .FirstOrDefaultAsync();

        return query;
    }
}
