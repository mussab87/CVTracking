using AutoMapper;
using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetAllCvListLocal { }


public class GetAllCvListLocalQueryHandler : IRequestHandler<GetAllCvListLocalQuery, List<LocalAgentHRPoolDto>>
{
    private readonly ILocalAgentRepository _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICVRepository _ICVRepository;
    readonly ILocalSelectedCVRepository _selectedCv;

    public GetAllCvListLocalQueryHandler(ILocalAgentRepository unitOfWork, IMapper mapper, ICVRepository iCVRepository, ILocalSelectedCVRepository selectedCv)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _ICVRepository = iCVRepository;
        _selectedCv = selectedCv;
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

            //get selectedCV
            var selectedCV = await _selectedCv.GetAsync(predicate: cv => cv.HRPoolId == cv.HRPoolId);
            if (selectedCV != null && selectedCV.Count > 0)
            {
                cv.selected = selectedCV[0];
            }
        }

        return result;
    }
}
