namespace App.Application.Features.LocalAgent.LocalAgentDtos { }

public class LocalAgentHRPoolDto
{
    public LocalAgent LocalAgent { get; set; }
    public CV CV { get; set; }
    public CVStatus CVStatus { get; set; }

    public HRPool cvHRpool { get; set; }
    public List<CVAttachment> cvAttachments { get; set; }

    public List<PreviousEmployment> previousEmployment { get; set; }

    public int[] Skills { get; set; }

    public bool RootSelected { get; set; }
}

