using MediatR;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignCvById { }

public class GetForeignCvByIdQuery : IRequest<ForeignAgentHRPoolDto>
{
    public int cvId { get; set; }
}

