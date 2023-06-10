
namespace App.Application.Contracts.Repositories { }

public interface IPreviousEmploymentsRepository : IAsyncRepository<PreviousEmployment>
{
    Task AddPreviousEmployments(CV cv, List<PreviousEmployment> previous, string foreignUserId);
}

