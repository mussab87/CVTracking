using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.ForeignAgent.Commands.CancelForeignCVByHRPoolId { }

public class CancelForeignCVByHRPoolIdRequestHandler : IRequestHandler<CancelForeignCVByHRPoolIdRequest, int>
{
    readonly ICVHRPool _cVHRPool;
    readonly ICVRepository _cV;
    readonly ICVStatusRepository _cvStatus;


    public CancelForeignCVByHRPoolIdRequestHandler(IMapper mapper,
     ICVHRPool cVHRPool, ICVStatusRepository cvStatus, ICVRepository cV)
    {
        _cVHRPool = cVHRPool;
        _cvStatus = cvStatus;
        _cV = cV;
    }

    public async Task<int> Handle(CancelForeignCVByHRPoolIdRequest request, CancellationToken cancellationToken)
    {
        var status = _cvStatus.GetAsync(predicate: status => status.StatusNo == (int)cvStatus.Canceled).Result.FirstOrDefault();
        //_cvStatus.GetByIdAsync((int)cvStatus.Canceled);

        //update HRPool status
        var existHRPoolToUpdate = _cVHRPool.GetAsync(predicate: cv => cv.CV.Id == request.CVId).Result.FirstOrDefault();
        existHRPoolToUpdate.IsCancel = request.IsCancel;
        existHRPoolToUpdate.CancelReasonId = request.CancelReasonId;
        existHRPoolToUpdate.CancelNotes = request.CancelNotes;
        existHRPoolToUpdate.CanceledById = request.CancelById;
        existHRPoolToUpdate.CancelDateTime = request.CancelDateTime;
        existHRPoolToUpdate.CVStatus = status;
        await _cVHRPool.UpdateAsync(existHRPoolToUpdate);

        return request.CVId;
    }
}

