
namespace App.Infrastructure.Repositories.Education { }
public class EducationRepository : RepositoryBase<Education>, IEducationRepository
{
    public EducationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
