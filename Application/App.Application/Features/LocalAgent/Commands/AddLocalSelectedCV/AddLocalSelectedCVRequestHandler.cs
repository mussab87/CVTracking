using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.LocalAgent.Commands.AddLocalSelectedCV { }

public class AddLocalSelectedCVRequestHandler : IRequestHandler<AddLocalSelectedCVRequest, int>
{
    readonly ILocalSelectedCVRepository _unitOfWork;
    readonly ICVStatusRepository _cvStatus;
    readonly ICVHRPool _ICVHRPoolRepository;
    readonly IMapper mapper;

    public AddLocalSelectedCVRequestHandler(ILocalSelectedCVRepository unitOfWork, IMapper mapper,
        ILogger<AddLocalSelectedCVRequestHandler> logger, ICVStatusRepository cvStatus, ICVHRPool iCVHRPoolRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.mapper = mapper;
        _cvStatus = cvStatus;
        _ICVHRPoolRepository = iCVHRPoolRepository;
    }

    public async Task<int> Handle(AddLocalSelectedCVRequest request, CancellationToken cancellationToken)
    {
        var selectedCv = await _unitOfWork.GetAsync(predicate: cv => cv.HRPoolId == request.HRPoolId);

        if (selectedCv != null && selectedCv.Count > 0)
        {
            //update exist selected cv to be selected again
            selectedCv[0].LocalAgentStatusId = (int)cvStatus.Processing;
            selectedCv[0].LastModifiedById = request.CreatedById;
            selectedCv[0].LastModifiedDate = DateTime.Now;
            //update selected cv in table
            await _unitOfWork.UpdateAsync(selectedCv[0]);

            //update cvHRPools status into sendToLocal
            await UpdateHRPoolStatus(request);

            return selectedCv[0].Id;
        }

        var selectedCV = new SelectedCv()
        {
            LocalAgentId = request.LocalAgentId,
            HRPoolId = request.HRPoolId,
            LocalAgentStatusId = (int)cvStatus.Processing,
            SelectedDateTime = DateTime.Now,
            RootAdminCompanyConfirmation = false,
            CreatedById = request.CreatedById,
            CreatedDate = DateTime.Now
        };

        //add selected cv into table
        await _unitOfWork.AddAsync(selectedCV);

        //update cvHRPools status into selected
        await UpdateHRPoolStatus(request);

        return selectedCV.Id;

    }

    private async Task UpdateHRPoolStatus(AddLocalSelectedCVRequest request)
    {
        var status = await _cvStatus.GetByIdAsync((int)cvStatus.Selected);
        var getHRPoolById = await _ICVHRPoolRepository.GetByIdAsync((int)request.HRPoolId);

        if (getHRPoolById == null)
        {
            throw new NotFoundException(nameof(HRPool), request.HRPoolId);
        }

        getHRPoolById.LastModifiedById = request.CreatedById;
        getHRPoolById.LastModifiedDate = DateTime.Now;
        getHRPoolById.CVStatus = status;

        await _ICVHRPoolRepository.UpdateAsync(getHRPoolById);
    }
}

