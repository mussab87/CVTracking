
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
            if (prev.PositionId is not null && prev.CountryOfEmploymentId != 0 && prev.Period != 0)
            {
                PreviousEmployment cvAttachment = new()
                {
                    Period = prev.Period,
                    CountryOfEmploymentId = prev.CountryOfEmploymentId,
                    PositionId = prev.PositionId,
                    CV = cv,
                    CreatedById = foreignUserId,
                    CreatedDate = DateTime.Now
                };
                previousEmployments.Add(cvAttachment);
            }

        }
        if (previousEmployments.Count > 0)
        {
            _dbContext.PreviousEmployments.AddRange(previousEmployments);
            _dbContext.SaveChanges();
        }

    }
}
