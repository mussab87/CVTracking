using AutoMapper;
using MediatR;

namespace App.Application.Features.RootCompany.Commands.SendCVToLocal { }
public class SendCVToLocalRequestHandler : IRequestHandler<SendCVToLocalRequest, bool>
{
    readonly ICVHRPool _ICVHRPoolRepository;
    readonly ICVStatusRepository _cvStatus;
    readonly IMapper _mapper;

    public SendCVToLocalRequestHandler(ICVHRPool unitOfWork, IMapper mapper, ICVStatusRepository cvStatus)
    {
        _ICVHRPoolRepository = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper;
        _cvStatus = cvStatus;
    }

    public async Task<bool> Handle(SendCVToLocalRequest request, CancellationToken cancellationToken)
    {
        var status = await _cvStatus.GetByIdAsync((int)cvStatus.SendToLocal);
        foreach (var hr in request.ForeignAgentHRPoolDto.Where(r => r.RootSelected))
        {
            var getHRPoolById = await _ICVHRPoolRepository.GetByIdAsync((int)hr.Id);
            if (getHRPoolById == null)
            {
                throw new NotFoundException(nameof(HRPool), hr.Id);
            }

            getHRPoolById.LocalAgentId = hr.LocalId;
            getHRPoolById.SendToLocalDateTime = DateTime.Now;
            getHRPoolById.CVStatus = status;
            await _ICVHRPoolRepository.UpdateAsync(getHRPoolById);
        }

        return true;
    }
}

