
namespace App.Application.Contracts.Repositories { }

public interface IAttachmentRepository : IAsyncRepository<Attachment>
{
    Task<List<Attachment>> AddAttachment(List<Attachment> attachments, string foreugnUserId);
    Task AddCVAttachment(CV cv, List<Attachment> attachments, string foreugnUserId);
}

