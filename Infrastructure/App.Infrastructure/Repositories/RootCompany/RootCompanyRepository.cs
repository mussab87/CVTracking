

using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.RootCompany { }
public class RootCompanyRepository : RepositoryBase<RootCompany>, IRootCompanyRepository
{
    public RootCompanyRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> AddUserToRootCompany(string applicationUserId, int rootCompanyId)
    {
        var query = new RootCompanyUsers { ApplicationUserId = applicationUserId, RootCompanyId = rootCompanyId };
        await _dbContext.AddAsync(query);
        await _dbContext.SaveChangesAsync();

        //var usersRootCompany = await _dbContext.RootCompanyUsers
        //                        .Include(u => u.ApplicationUser).Include(u => u.RootCompany).ToListAsync();

        return await _dbContext.SaveChangesAsync();
    }
}
