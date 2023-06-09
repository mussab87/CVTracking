using MediatR;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignAgentById { }

public class GetAllCvListQuery : IRequest<List<ForeignAgentHRPoolDto>>
{
    public int ForeignAgentId { get; set; }
}

