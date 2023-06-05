namespace App.Infrastructure.Repositories.RootCompany { }
public class RootCompanyRepository : RepositoryBase<RootCompany>, IRootCompanyRepository
{
    public RootCompanyRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
