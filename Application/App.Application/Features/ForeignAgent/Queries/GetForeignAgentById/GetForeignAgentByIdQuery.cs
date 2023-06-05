using MediatR;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignAgentById { }

public class GetForeignAgentByIdQuery : IRequest<ForegnAgentDto>
{
    public int ForeignAgentId { get; set; }
}

