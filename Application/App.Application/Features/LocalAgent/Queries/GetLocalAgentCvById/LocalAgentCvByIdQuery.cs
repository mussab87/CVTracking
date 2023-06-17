using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetLocalAgentCvById { }

public class LocalAgentCvByIdQuery : IRequest<ForeignAgentHRPoolDto>
{
    public int cvId { get; set; }
}

