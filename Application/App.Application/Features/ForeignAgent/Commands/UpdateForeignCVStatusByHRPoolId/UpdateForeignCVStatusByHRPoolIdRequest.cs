using MediatR;

namespace App.Application.Features.ForeignAgent.Commands.UpdateForeignCVStatusByHRPoolId { }

public class UpdateForeignCVStatusByHRPoolIdRequest : IRequest<int>
{
    public int CVId { get; set; }
    public string foreignAgentUserId { get; set; }
}

