namespace App.Application.Features.ForeignAgent.ForeignAgentDtos { }

public class ForeignAgentHRPoolDto
{
    public int? Id { get; set; }
    public ForeignAgent ForeignAgent { get; set; }
    public CV CV { get; set; }
    public CVStatus CVStatus { get; set; }

    public HRPool cvHRpool { get; set; }
    public List<CVAttachment> cvAttachments { get; set; }

    public List<PreviousEmployment> previousEmployment { get; set; }

    public LocalAgent LocalAgent { get; set; }

    public int[] Skills { get; set; }

    public bool RootSelected { get; set; }

    public int? LocalId { get; set; }

    public List<SkillSelectedDto> skillList { get; set; }

    public SelectedCv selected { get; set; }
}

