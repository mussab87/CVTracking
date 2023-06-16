using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.ForeignAgent.Commands.UpdateForeignCVStatusByHRPoolId { }

public class UpdateForeignCVStatusByHRPoolIdRequestHandler : IRequestHandler<UpdateForeignCVStatusByHRPoolIdRequest, int>
{

    readonly IMapper _mapper;
    readonly ICVHRPool _cVHRPool;
    readonly ICVStatusRepository _cvStatus;


    public UpdateForeignCVStatusByHRPoolIdRequestHandler(IMapper mapper,
     ICVHRPool cVHRPool, ICVStatusRepository cvStatus)
    {
        _mapper = mapper;
        _cVHRPool = cVHRPool;
        _cvStatus = cvStatus;
    }

    public async Task<int> Handle(UpdateForeignCVStatusByHRPoolIdRequest request, CancellationToken cancellationToken)
    {
        var status = await _cvStatus.GetByIdAsync((int)cvStatus.PostToAdmin);

        //update HRPool status
        var existHRPoolToUpdate = _cVHRPool.GetAsync(predicate: cv => cv.CV.Id == request.CVId).Result.FirstOrDefault();
        existHRPoolToUpdate.LastModifiedById = request.foreignAgentUserId;
        existHRPoolToUpdate.LastModifiedDate = DateTime.Now;
        existHRPoolToUpdate.CVStatus = status;
        await _cVHRPool.UpdateAsync(existHRPoolToUpdate);

        return request.CVId;
    }
}

