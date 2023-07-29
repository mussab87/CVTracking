using MediatR;

namespace App.Application.Features.CancelReason.Queries.GetCancelReasonList { }
public class GetCancelReasonListQuery : IRequest<List<CancelReasonDto>>
{
}
