
namespace App.Infrastructure.Repositories.Attachment { }
public class CVAttachmentRepository : RepositoryBase<CVAttachment>, ICVAttachmentRepository
{
    public CVAttachmentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
