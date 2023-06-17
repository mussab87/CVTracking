//using AutoMapper;
//using MediatR;

//namespace App.Application.Features.LocalAgent.Queries.GetLocalAgentCvById { }


//public class LocalAgentCvByIdQueryHandler : IRequestHandler<LocalAgentCvByIdQuery, ForeignAgentHRPoolDto>
//{
//    private readonly ICVRepository _unitOfWork;
//    private readonly IMapper _mapper;
//    private readonly ICandidateSkillsRepository _candidateSkillsRepository;

//    public LocalAgentCvByIdQueryHandler(ICVRepository unitOfWork, IMapper mapper, ICandidateSkillsRepository candidateSkillsRepository)
//    {
//        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
//        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//        _candidateSkillsRepository = candidateSkillsRepository;
//    }

//    public async Task<ForeignAgentHRPoolDto> Handle(LocalAgentCvByIdQuery request,
//            CancellationToken cancellationToken)
//    {
//        var foregnAgentCv = await _unitOfWork.LocalAgentCvById(request.cvId);

//        //get cv attachments list & prevous employment list
//        var Cvattachments = await _unitOfWork.GetCvAttachmentByCvId(request.cvId);

//        //get cv prevous employment
//        var cvPreviousEmployment = await _unitOfWork.GetCvPreviousEmploymentByCvId(request.cvId);

//        //add attachments & PreviousEmployment into foregnAgentCv

//        //get candidate skils
//        var skills = await _candidateSkillsRepository.GetCVCandidateSkills(request.cvId);
//        int[] skillList = null;
//        if (skills.Count > 0)
//        {
//            skillList = new int[skills.Count];
//            for (int i = 0; i < skills.Count; i++)
//            {
//                var skillId = skills[i].CandidateSkillsId;
//                skillList[i] = skillId;
//            }
//        }

//        ForeignAgentHRPoolDto foreignAgentHRPoolDto = new();
//        foreignAgentHRPoolDto.ForeignAgent = foregnAgentCv.ForeignAgent;
//        foreignAgentHRPoolDto.CV = foregnAgentCv.CV;
//        foreignAgentHRPoolDto.CVStatus = foregnAgentCv.CVStatus;
//        foreignAgentHRPoolDto.cvAttachments = Cvattachments;
//        foreignAgentHRPoolDto.previousEmployment = cvPreviousEmployment;
//        foreignAgentHRPoolDto.cvHRpool = foregnAgentCv;
//        foreignAgentHRPoolDto.Skills = skillList;

//        return foreignAgentHRPoolDto;
//    }
//}
