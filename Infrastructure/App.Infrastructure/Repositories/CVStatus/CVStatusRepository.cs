
namespace App.Infrastructure.Repositories.CVStatus { }
public class CVStatusRepository : RepositoryBase<CVStatus>, ICVStatusRepository
{
    public CVStatusRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
