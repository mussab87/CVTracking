
namespace App.Infrastructure.Repositories.Designation { }
public class DesignationRepository : RepositoryBase<Designation>, IDesignationRepository
{
    public DesignationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
