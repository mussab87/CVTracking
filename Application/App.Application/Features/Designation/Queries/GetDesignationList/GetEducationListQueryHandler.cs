using AutoMapper;
using MediatR;

namespace App.Application.Features.Designation.Queries.GetDesignationList { }
public class GetDesignationListQueryHandler : IRequestHandler<GetDesignationListQuery, List<DesignationDto>>
{
    private readonly IDesignationRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetDesignationListQueryHandler(IDesignationRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<DesignationDto>> Handle(GetDesignationListQuery request,
            CancellationToken cancellationToken)
    {
        var designationList = await _unitOfWork.GetAllAsync();
        return _mapper.Map<List<DesignationDto>>(designationList.ToList());
    }
}

