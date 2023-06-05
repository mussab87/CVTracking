using AutoMapper;
using MediatR;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignAgentList { }


public class GetForeignAgentListQueryHandler : IRequestHandler<GetForeignAgentListQuery, List<ForegnAgentDto>>
{
    private readonly IForeignAgentRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetForeignAgentListQueryHandler(IForeignAgentRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<ForegnAgentDto>> Handle(GetForeignAgentListQuery request,
            CancellationToken cancellationToken)
    {
        var foregnAgentList = await _unitOfWork.GetForeignAgentByRootCompanyId(request.rootCompanyId);
        return _mapper.Map<List<ForegnAgentDto>>(foregnAgentList);
    }
}
