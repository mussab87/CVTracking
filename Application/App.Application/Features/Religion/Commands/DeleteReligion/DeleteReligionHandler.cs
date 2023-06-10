using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.Religion.Commands.DeleteReligion { }

public class DeleteReligionHandler : IRequestHandler<DeleteReligionRequest>
{
    readonly IReligionRepository _unitOfWork;
    readonly IMapper _mapper;

    public DeleteReligionHandler(IReligionRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Handle(DeleteReligionRequest request, CancellationToken cancellationToken)
    {
        var religionToDelete = await _unitOfWork.GetByIdAsync(request.Id);
        if (religionToDelete == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        religionToDelete.Status = false;
        await _unitOfWork.UpdateAsync(religionToDelete);

        return;
    }
}

