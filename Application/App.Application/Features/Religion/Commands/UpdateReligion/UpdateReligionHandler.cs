using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.Religion.Commands.UpdateReligion { }
public class UpdateReligionHandler : IRequestHandler<UpdateReligionRequest>
{
    readonly IReligionRepository _unitOfWork;
    readonly IMapper _mapper;

    public UpdateReligionHandler(IReligionRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateReligionRequest request, CancellationToken cancellationToken)
    {
        var religionToUpdate = await _unitOfWork.GetByIdAsync(request.Id);
        if (religionToUpdate == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        _mapper.Map(request, religionToUpdate, typeof(UpdateReligionRequest), typeof(Religion));

        await _unitOfWork.UpdateAsync(religionToUpdate);

        return;
    }
}

