using MediatR;

namespace App.Application.Features.LocalAgent.Commands.UpdateLocalCVStatusByHRPoolId { }

public class UpdateLocalCVStatusByHRPoolIdRequest : IRequest<int>
{
    public int CVId { get; set; }
    public string LocalAgentUserId { get; set; }
}

