
namespace App.Infrastructure.Repositories.Cities { }
public class PreviousEmploymentsRepository : RepositoryBase<PreviousEmployment>, IPreviousEmploymentsRepository
{
    public PreviousEmploymentsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddPreviousEmployments(CV cv, List<PreviousEmployment> previous, string foreignUserId)
    {
        List<PreviousEmployment> previousEmployments = new();
        foreach (var prev in previous)
        {
            PreviousEmployment cvAttachment = new()
            {
                Period = prev.Period,
                CountryOfEmploymentId = prev.CountryOfEmploymentId,
                Position = prev.Position,
                CV = cv,
                CreatedById = foreignUserId,
                CreatedDate = DateTime.Now
            };
            previousEmployments.Add(cvAttachment);
        }
        if (previousEmployments.Count > 0)
            await _dbContext.PreviousEmployments.AddRangeAsync(previousEmployments);
    }
}
