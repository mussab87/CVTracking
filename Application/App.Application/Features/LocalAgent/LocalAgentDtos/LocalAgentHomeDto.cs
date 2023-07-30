namespace App.Application.Features.LocalAgent.LocalAgentDtos { }

public class LocalAgentHomeDto
{
    public LocalAgentHomeDto()
    {
        LocalHrPool = new();
        ForegnAgent = new();
        CountCancel = new();
    }
    public List<LocalAgentHRPoolDto> LocalHrPool { get; set; }

    public List<ForegnAgentDto> ForegnAgent { get; set; }

    public List<CountCancelCVDto> CountCancel { get; set; }
}

