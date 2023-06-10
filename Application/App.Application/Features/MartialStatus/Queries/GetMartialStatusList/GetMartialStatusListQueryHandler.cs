using AutoMapper;
using MediatR;

namespace App.Application.Features.MartialStatus.Queries.GetMartialStatusList { }
public class GetMartialStatusListQueryHandler : IRequestHandler<GetMartialStatusListQuery, List<MartialStatusDto>>
{
    private readonly IMartialStatusRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetMartialStatusListQueryHandler(IMartialStatusRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<MartialStatusDto>> Handle(GetMartialStatusListQuery request,
            CancellationToken cancellationToken)
    {
        var martialStatusList = await _unitOfWork.GetAllAsync();
        return _mapper.Map<List<MartialStatusDto>>(martialStatusList.ToList());
    }
}

