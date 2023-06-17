using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetAllCvListLocal { }

public class GetAllCvListLocalQuery : IRequest<List<LocalAgentHRPoolDto>>
{
    public int LocalAgentId { get; set; }
}

