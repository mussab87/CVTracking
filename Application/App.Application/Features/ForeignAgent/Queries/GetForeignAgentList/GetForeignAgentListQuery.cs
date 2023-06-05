using MediatR;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignAgentList { }

public class GetForeignAgentListQuery : IRequest<List<ForegnAgentDto>>
{
    public int rootCompanyId { get; set; }
}

