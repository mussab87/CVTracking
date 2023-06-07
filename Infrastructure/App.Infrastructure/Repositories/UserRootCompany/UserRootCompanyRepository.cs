
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.IUserRootCompany { }

public class UserRootCompanyRepository : RepositoryBase<RootCompany>, IUserRootCompanyRepository
{
    public UserRootCompanyRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> AddUserToRootCompany(string applicationUserId, int rootCompanyId)
    {
        var query = new RootCompanyUsers { ApplicationUserId = applicationUserId, RootCompanyId = rootCompanyId };
        await _dbContext.AddAsync(query);
        //update user table by rootCompanyId 
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == applicationUserId);
        user.RootCompanyId = rootCompanyId;

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ApplicationUser>> GetAllUserInRootCompany(int rootCompanyId)
    {
        return await _dbContext.RootCompanyUsers
                        .Where(u => u.RootCompanyId == rootCompanyId)
                        .Include(u => u.ApplicationUser).Select(u => u.ApplicationUser)
                        .ToListAsync();
    }
}

