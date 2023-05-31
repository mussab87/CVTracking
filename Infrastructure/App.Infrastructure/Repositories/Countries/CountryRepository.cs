
namespace App.Infrastructure.Repositories.Cities { }
public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
