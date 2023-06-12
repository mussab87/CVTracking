
namespace App.Infrastructure.Repositories.Attachment { }
public class AttachmentRepository : RepositoryBase<Attachment>, IAttachmentRepository
{
    public AttachmentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddCVAttachment(CV cv, List<Attachment> attachments, string foreugnUserId)
    {
        List<CVAttachment> cVAttachments = new();
        foreach (var attachment in attachments)
        {
            CVAttachment cvAttachment = new CVAttachment()
            {
                CVId = cv.Id,
                AttachmentId = attachment.Id,
                CreatedById = foreugnUserId,
                CreatedDate = DateTime.Now
            };
            cVAttachments.Add(cvAttachment);
        }
        if (cVAttachments.Count > 0)
            await _dbContext.CVAttachments.AddRangeAsync(cVAttachments);
        _dbContext.SaveChanges();
    }

    public async Task<List<Attachment>> AddAttachment(List<Attachment> attachments, string foreugnUserId)
    {
        List<Attachment> Attachments = new();
        foreach (var attachment in attachments)
        {
            Attachment cvAttachment = new()
            {
                Path = attachment.Path,
                AttachmentTypeId = attachment.AttachmentTypeId,
                CreatedById = foreugnUserId,
                CreatedDate = DateTime.Now
            };
            Attachments.Add(cvAttachment);
        }
        if (Attachments.Count > 0)
            await _dbContext.Attachments.AddRangeAsync(Attachments);
        _dbContext.SaveChanges();

        return Attachments;
    }
}
