
namespace App.Infrastructure.Repositories.CancelReason { }
public class CancelReasonRepository : RepositoryBase<CancelReason>, ICancelReasonRepository
{
    public CancelReasonRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
