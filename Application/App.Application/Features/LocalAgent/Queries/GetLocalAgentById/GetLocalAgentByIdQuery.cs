using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetLocalAgentById { }

public class GetLocalAgentByIdQuery : IRequest<LocalAgentDto>
{
    public int LocalAgentId { get; set; }
}

