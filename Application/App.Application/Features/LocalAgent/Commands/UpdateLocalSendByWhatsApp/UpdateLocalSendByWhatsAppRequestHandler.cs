using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.LocalAgent.Commands.UpdateLocalSendByWhatsApp { }

public class UpdateLocalSendByWhatsAppRequestHandler : IRequestHandler<UpdateLocalSendByWhatsAppRequest, int>
{
    readonly ICVHRPool _ICVHRPoolRepository;
    readonly IMapper mapper;

    public UpdateLocalSendByWhatsAppRequestHandler(IMapper mapper, ICVHRPool iCVHRPoolRepository)
    {
        this.mapper = mapper;
        _ICVHRPoolRepository = iCVHRPoolRepository;
    }

    public async Task<int> Handle(UpdateLocalSendByWhatsAppRequest request, CancellationToken cancellationToken)
    {
        var selectedCv = await _ICVHRPoolRepository.GetAsync(predicate: cv => cv.Id == request.HRPoolId);

        if (selectedCv.Count < 0 || selectedCv is null)
        {
            throw new NotFoundException(nameof(HRPool), request.HRPoolId);
        }

        selectedCv[0].SendByWhatapp = request.SendStatus;
        selectedCv[0].SendByWhatappDateTime = request.SendByWhatsAppDate;
        await _ICVHRPoolRepository.UpdateAsync(selectedCv[0]);

        return selectedCv[0].Id;
    }
}

