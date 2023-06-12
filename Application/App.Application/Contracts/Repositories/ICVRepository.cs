
namespace App.Application.Contracts.Repositories { }
public interface ICVRepository : IAsyncRepository<CV>
{
    Task AddHRPool(CV cv, ForeignAgent ForeignAgent, CVStatus status, string userId);
    Task<HRPool> GetForeignCvById(int ForeignAgentId);
    Task<List<CVAttachment>> GetCvAttachmentByCvId(int cvId);
    Task<List<PreviousEmployment>> GetCvPreviousEmploymentByCvId(int cvId);
}

