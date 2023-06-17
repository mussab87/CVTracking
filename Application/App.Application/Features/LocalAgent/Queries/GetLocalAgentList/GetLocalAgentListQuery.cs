using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetLocalAgentList { }

public class GetLocalAgentListQuery : IRequest<List<LocalAgentDto>>
{
    public int rootCompanyId { get; set; }
}

