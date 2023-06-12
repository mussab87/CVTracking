namespace App.Application.Features.ForeignAgent.ForeignAgentDtos { }

public class ForeignAgentHRPoolDto
{
    public ForeignAgent ForeignAgent { get; set; }
    public CV CV { get; set; }
    public CVStatus CVStatus { get; set; }

    public List<Attachment> cvAttachments { get; set; }

    public List<PreviousEmployment> previousEmployment { get; set; }
}

