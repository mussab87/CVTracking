//using AutoMapper;
//using MediatR;

//namespace App.Application.Features.LocalAgent.Queries.GetAllCvListLocal { }


//public class GetAllCvListLocalQueryHandler : IRequestHandler<GetAllCvListQuery, List<LocalAgentHRPoolDto>>
//{
//    private readonly ILocalAgentRepository _unitOfWork;
//    private readonly IMapper _mapper;

//    public GetAllCvListLocalQueryHandler(ILocalAgentRepository unitOfWork, IMapper mapper)
//    {
//        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
//        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//    }

//    public async Task<List<LocalAgentHRPoolDto>> Handle(GetAllCvListQuery request,
//            CancellationToken cancellationToken)
//    {
//        var foregnAgentCvs = await _unitOfWork.GetAllLocalAgentCvList(request.LocalAgentId);
//        return _mapper.Map<List<LocalAgentHRPoolDto>>(foregnAgentCvs);
//    }
//}
