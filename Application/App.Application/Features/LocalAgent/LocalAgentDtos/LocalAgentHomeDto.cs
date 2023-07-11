namespace App.Application.Features.LocalAgent.LocalAgentDtos { }

public class LocalAgentHomeDto
{
    public LocalAgentHomeDto()
    {
        LocalHrPool = new();
        ForegnAgent = new();
    }
    public List<LocalAgentHRPoolDto> LocalHrPool { get; set; }

    public List<ForegnAgentDto> ForegnAgent { get; set; }
}

