using AutoMapper;
using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetLocalAgentById { }


public class GetLocalAgentByIdQueryHandler : IRequestHandler<GetLocalAgentByIdQuery, LocalAgentDto>
{
    private readonly ILocalAgentRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetLocalAgentByIdQueryHandler(ILocalAgentRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<LocalAgentDto> Handle(GetLocalAgentByIdQuery request,
            CancellationToken cancellationToken)
    {
        var localAgent = await _unitOfWork.GetByIdAsync(request.LocalAgentId);
        return _mapper.Map<LocalAgentDto>(localAgent);
    }
}
