using AutoMapper;
using MediatR;

namespace App.Application.Features.LocalAgent.Queries.GetAllCvListLocal { }


public class GetAllCvListLocalQueryHandler : IRequestHandler<GetAllCvListLocalQuery, List<LocalAgentHRPoolDto>>
{
    private readonly ILocalAgentRepository _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICVRepository _ICVRepository;
    readonly ILocalSelectedCVRepository _selectedCv;
    readonly ICVStatusRepository _cvStatus;
    readonly ICVHRPool _ICVHRPoolRepository;

    public GetAllCvListLocalQueryHandler(ILocalAgentRepository unitOfWork, IMapper mapper, ICVRepository iCVRepository, ILocalSelectedCVRepository selectedCv, ICVStatusRepository cvStatus, ICVHRPool iCVHRPoolRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _ICVRepository = iCVRepository;
        _selectedCv = selectedCv;
        _cvStatus = cvStatus;
        _ICVHRPoolRepository = iCVHRPoolRepository;
    }

    public async Task<List<LocalAgentHRPoolDto>> Handle(GetAllCvListLocalQuery request,
            CancellationToken cancellationToken)
    {
        await CheckSelectedCv(request);

        //get list after applied 5 working days 
        var foregnAgentCvsResult = await _unitOfWork.GetAllLocalAgentCvList(request.LocalAgentId);
        var result = _mapper.Map<List<LocalAgentHRPoolDto>>(foregnAgentCvsResult);
        foreach (var cv in result)
        {
            //get cv attachments list & prevous employment list
            var Cvattachments = await _ICVRepository.GetCvAttachmentByCvId(cv.CV.Id);

            cv.cvAttachments = Cvattachments;

            //get selectedCV
            var selectedCV = await _selectedCv.GetAsync(predicate: c => c.HRPoolId == cv.Id);
            if (selectedCV != null && selectedCV.Count > 0)
            {
                cv.selected = selectedCV[0];
            }
        }

        return result;
    }

    private async Task CheckSelectedCv(GetAllCvListLocalQuery request)
    {
        var foregnAgentCvs = await _unitOfWork.GetAllLocalAgentCvList(request.LocalAgentId);

        foreach (var c in foregnAgentCvs)
        {
            var selectedCV = await _selectedCv.GetAsync(predicate: cv => cv.HRPoolId == c.Id);
            if (selectedCV != null && selectedCV.Count > 0)
            {
                if (selectedCV[0].LocalAgentStatusId != (int)cvStatus.Employeed)
                {
                    //check selected cv exceed 5 working days - in case yes change cv status into sendToLocal
                    //01/07/2023
                    var selectedDate = new DateTime(selectedCV[0].SelectedDateTime.Date.Year,
                                                        selectedCV[0].SelectedDateTime.Date.Month,
                                                        selectedCV[0].SelectedDateTime.Date.Day);
                    //06/07/2023
                    var dateNow = new DateTime(DateTime.Now.Date.Year,
                                                        DateTime.Now.Date.Month,
                                                        DateTime.Now.Date.Day);

                    var datesExceed = (dateNow - selectedDate).Days;
                    if (datesExceed >= 5)
                    {
                        await _selectedCv.DeleteAsync(selectedCV[0]);

                        //update cvStatus in HRPool into SendToLocal
                        c.CVStatus = await _cvStatus.GetByIdAsync((int)cvStatus.PostToAdmin);
                        c.LocalAgentId = null;
                        c.SendToLocalDateTime = null;
                        await _ICVHRPoolRepository.UpdateAsync(c);
                    }
                }

            }
        }
    }
}
