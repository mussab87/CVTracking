
namespace App.Infrastructure.Repositories.Cities { }
public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
