using AutoMapper;
using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetAllCvListLocal { }


public class GetAllCvListLocalQueryHandler : IRequestHandler<GetAllCvListLocalQuery, List<LocalAgentHRPoolDto>>
{
    private readonly ILocalAgentRepository _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICVRepository _ICVRepository;

    public GetAllCvListLocalQueryHandler(ILocalAgentRepository unitOfWork, IMapper mapper, ICVRepository iCVRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _ICVRepository = iCVRepository;
    }

    public async Task<List<LocalAgentHRPoolDto>> Handle(GetAllCvListLocalQuery request,
            CancellationToken cancellationToken)
    {
        var foregnAgentCvs = await _unitOfWork.GetAllLocalAgentCvList(request.LocalAgentId);

        var result = _mapper.Map<List<LocalAgentHRPoolDto>>(foregnAgentCvs);
        foreach (var cv in result)
        {
            //get cv attachments list & prevous employment list
            var Cvattachments = await _ICVRepository.GetCvAttachmentByCvId(cv.CV.Id);

            cv.cvAttachments = Cvattachments;
        }

        return result;
    }
}
