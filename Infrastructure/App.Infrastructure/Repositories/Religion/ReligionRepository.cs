
namespace App.Infrastructure.Repositories.Religion { }
public class ReligionRepository : RepositoryBase<Religion>, IReligionRepository
{
    public ReligionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
