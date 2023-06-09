using AutoMapper;
using MediatR;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignAgentById { }


public class GetAllCvListQueryHandler : IRequestHandler<GetAllCvListQuery, List<ForeignAgentHRPoolDto>>
{
    private readonly IForeignAgentRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCvListQueryHandler(IForeignAgentRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<ForeignAgentHRPoolDto>> Handle(GetAllCvListQuery request,
            CancellationToken cancellationToken)
    {
        var foregnAgentCvs = await _unitOfWork.GetAllForeignAgentCvList(request.ForeignAgentId);
        return _mapper.Map<List<ForeignAgentHRPoolDto>>(foregnAgentCvs);
    }
}
