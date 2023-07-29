namespace App.Application.Features.LocalAgent.LocalAgentDtos { }

public class LocalAgentHRPoolDto
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

    public bool LocalSelected { get; set; }

    public int? LocalId { get; set; }

    public List<SkillSelectedDto> skillList { get; set; }
    public SelectedCv selected { get; set; }

    public bool? SendByWhatapp { get; set; }

    public bool? IsCancel { get; set; }
    public int? CancelReasonId { get; set; }
    public string CancelNotes { get; set; }
    public string? CanceledById { get; set; }
    public DateTime? CancelDateTime { get; set; }

    public ApplicationUser CanceledBy { get; set; }
    public CancelReason CancelReason { get; set; }
}

