using AutoMapper;
using MediatR;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignAgentById { }


public class GetForeignAgentByIdQueryHandler : IRequestHandler<GetForeignAgentByIdQuery, ForegnAgentDto>
{
    private readonly IForeignAgentRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetForeignAgentByIdQueryHandler(IForeignAgentRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ForegnAgentDto> Handle(GetForeignAgentByIdQuery request,
            CancellationToken cancellationToken)
    {
        var foregnAgent = await _unitOfWork.GetByIdAsync(request.ForeignAgentId);
        return _mapper.Map<ForegnAgentDto>(foregnAgent);
    }
}
