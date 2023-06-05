using AutoMapper;
using MediatR;

namespace App.Application.Features.ForeignAgent.Commands.UpdateForeignAgent { }
public class UpdateForeignAgentRequestHandler : IRequestHandler<UpdateForeignAgentRequest>
{
    readonly IForeignAgentRepository _unitOfWork;
    readonly IMapper _mapper;

    public UpdateForeignAgentRequestHandler(IForeignAgentRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper;
    }

    public async Task Handle(UpdateForeignAgentRequest request, CancellationToken cancellationToken)
    {
        var foreignAgentToUpdate = await _unitOfWork.GetByIdAsync(request.Id);
        if (foreignAgentToUpdate == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        _mapper.Map(request, foreignAgentToUpdate, typeof(UpdateForeignAgentRequest), typeof(ForeignAgent));

        await _unitOfWork.UpdateAsync(foreignAgentToUpdate);

        return;
    }
}

