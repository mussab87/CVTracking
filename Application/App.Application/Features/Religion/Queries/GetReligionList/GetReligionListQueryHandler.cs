using AutoMapper;
using MediatR;

namespace App.Application.Features.Religion.Queries.GetReligionList { }
public class GetReligionListQueryHandler : IRequestHandler<GetReligionListQuery, List<ReligionDto>>
{
    private readonly IReligionRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetReligionListQueryHandler(IReligionRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<ReligionDto>> Handle(GetReligionListQuery request,
            CancellationToken cancellationToken)
    {
        var religionList = await _unitOfWork.GetAllAsync();
        return _mapper.Map<List<ReligionDto>>(religionList.ToList());
    }
}

