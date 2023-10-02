using AutoMapper;
using MediatR;

namespace App.Application.Features.Education.Queries.GetEducationList { }
public class GetEducationListQueryHandler : IRequestHandler<GetEducationListQuery, List<EducationDto>>
{
    private readonly IEducationRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetEducationListQueryHandler(IEducationRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<EducationDto>> Handle(GetEducationListQuery request,
            CancellationToken cancellationToken)
    {
        var educationList = await _unitOfWork.GetAllAsync();
        return _mapper.Map<List<EducationDto>>(educationList.ToList());
    }
}

