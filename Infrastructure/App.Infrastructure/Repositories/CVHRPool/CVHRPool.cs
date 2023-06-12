
namespace App.Infrastructure.Repositories.CVHRPool { }
public class CVHRPool : RepositoryBase<HRPool>, ICVHRPool
{
    public CVHRPool(AppDbContext dbContext) : base(dbContext)
    {
    }
}
