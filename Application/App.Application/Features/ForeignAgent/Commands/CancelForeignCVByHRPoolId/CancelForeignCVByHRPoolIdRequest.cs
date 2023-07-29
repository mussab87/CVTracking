using MediatR;

namespace App.Application.Features.ForeignAgent.Commands.CancelForeignCVByHRPoolId { }

public class CancelForeignCVByHRPoolIdRequest : IRequest<int>
{
    public int HRPoolId { get; set; }
    public int CVId { get; set; }
    public bool IsCancel { get; set; }
    public int CancelReasonId { get; set; }
    public string CancelNotes { get; set; }
    public string CancelById { get; set; }
    public DateTime CancelDateTime { get; set; }
}

