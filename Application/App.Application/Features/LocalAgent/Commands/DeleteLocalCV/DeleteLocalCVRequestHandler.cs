using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.LocalAgent.Commands.UpdateLocalSendByWhatsApp { }

public class DeleteLocalCVRequestHandler : IRequestHandler<DeleteLocalCVRequest, int>
{
    readonly ICVRepository _ICVRepository;
    readonly IMapper mapper;

    public DeleteLocalCVRequestHandler(IMapper mapper, ICVRepository iCVHRPoolRepository)
    {
        this.mapper = mapper;
        _ICVRepository = iCVHRPoolRepository;
    }

    public async Task<int> Handle(DeleteLocalCVRequest request, CancellationToken cancellationToken)
    {
        var selectedCv = await _ICVRepository.GetAsync(predicate: cv => cv.Id == request.CVId);

        if (selectedCv.Count < 0 || selectedCv is null)
        {
            throw new NotFoundException(nameof(HRPool), request.CVId);
        }
        await _ICVRepository.DeleteAsync(selectedCv[0]);

        return selectedCv[0].Id;
    }
}

