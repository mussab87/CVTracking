
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace App.Domain.Entities { }
public class CVAttachment : EntityBase
{
    public int CVId { get; set; }
    public CV CV { get; set; }

    public int AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}

