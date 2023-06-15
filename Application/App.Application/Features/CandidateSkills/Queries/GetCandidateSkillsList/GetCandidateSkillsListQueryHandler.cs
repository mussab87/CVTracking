using AutoMapper;
using MediatR;

namespace App.Application.Features.CandidateSkills.Queries.GetCandidateSkillsList { }
public class GetCandidateSkillsListQueryHandler : IRequestHandler<GetCandidateSkillsListQuery, List<SkillsDto>>
{
    private readonly ICandidateSkillsRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetCandidateSkillsListQueryHandler(ICandidateSkillsRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<SkillsDto>> Handle(GetCandidateSkillsListQuery request,
            CancellationToken cancellationToken)
    {
        var skillsList = await _unitOfWork.GetAllAsync();
        return _mapper.Map<List<SkillsDto>>(skillsList);
    }
}

