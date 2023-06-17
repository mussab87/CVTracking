using AutoMapper;
using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetLocalAgentList { }


public class GetLocalAgentListQueryHandler : IRequestHandler<GetLocalAgentListQuery, List<LocalAgentDto>>
{
    private readonly ILocalAgentRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetLocalAgentListQueryHandler(ILocalAgentRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<LocalAgentDto>> Handle(GetLocalAgentListQuery request,
            CancellationToken cancellationToken)
    {
        var LocalAgentList = await _unitOfWork.GetLocalAgentByRootCompanyId(request.rootCompanyId);
        return _mapper.Map<List<LocalAgentDto>>(LocalAgentList);
    }
}
