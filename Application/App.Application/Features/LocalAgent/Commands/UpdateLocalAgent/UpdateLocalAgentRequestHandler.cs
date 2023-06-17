using AutoMapper;
using MediatR;

namespace App.Application.Features.LocalAgent.Commands.UpdateLocalAgent { }
public class UpdateLocalAgentRequestHandler : IRequestHandler<UpdateLocalAgentRequest>
{
    readonly ILocalAgentRepository _unitOfWork;
    readonly IMapper _mapper;

    public UpdateLocalAgentRequestHandler(ILocalAgentRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper;
    }

    public async Task Handle(UpdateLocalAgentRequest request, CancellationToken cancellationToken)
    {
        var LocalAgentToUpdate = await _unitOfWork.GetByIdAsync(request.Id);
        if (LocalAgentToUpdate == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        _mapper.Map(request, LocalAgentToUpdate, typeof(UpdateLocalAgentRequest), typeof(LocalAgent));

        await _unitOfWork.UpdateAsync(LocalAgentToUpdate);

        return;
    }
}

