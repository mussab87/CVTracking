using AutoMapper;
using MediatR;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignCvById { }


public class GetForeignCvByIdQueryHandler : IRequestHandler<GetForeignCvByIdQuery, ForeignAgentHRPoolDto>
{
    private readonly ICVRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetForeignCvByIdQueryHandler(ICVRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ForeignAgentHRPoolDto> Handle(GetForeignCvByIdQuery request,
            CancellationToken cancellationToken)
    {
        var foregnAgentCv = await _unitOfWork.GetForeignCvById(request.cvId);

        //get cv attachments list & prevous employment list
        var Cvattachments = await _unitOfWork.GetCvAttachmentByCvId(request.cvId);

        //get cv prevous employment
        var cvPreviousEmployment = await _unitOfWork.GetCvPreviousEmploymentByCvId(request.cvId);

        //add attachments & PreviousEmployment into foregnAgentCv

        ForeignAgentHRPoolDto foreignAgentHRPoolDto = new();
        foreignAgentHRPoolDto.ForeignAgent = foregnAgentCv.ForeignAgent;
        foreignAgentHRPoolDto.CV = foregnAgentCv.CV;
        foreignAgentHRPoolDto.CVStatus = foregnAgentCv.CVStatus;
        foreignAgentHRPoolDto.cvAttachments = Cvattachments;
        foreignAgentHRPoolDto.previousEmployment = cvPreviousEmployment;
        foreignAgentHRPoolDto.cvHRpool = foregnAgentCv;


        return foreignAgentHRPoolDto;
    }
}
