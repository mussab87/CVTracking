
namespace App.Infrastructure.Repositories.MartialStatus { }
public class MartialStatusRepository : RepositoryBase<MartialStatus>, IMartialStatusRepository
{
    public MartialStatusRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
