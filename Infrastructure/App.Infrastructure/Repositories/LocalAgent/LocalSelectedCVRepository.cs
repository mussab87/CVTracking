using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.LocalAgent { }

public class LocalSelectedCVRepository : RepositoryBase<SelectedCv>, ILocalSelectedCVRepository
{
    public LocalSelectedCVRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

