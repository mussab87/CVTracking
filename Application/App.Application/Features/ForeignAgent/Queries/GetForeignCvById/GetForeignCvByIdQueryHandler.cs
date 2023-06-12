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
        var foregnAgentCvs = await _unitOfWork.GetForeignCvById(request.cvId);
        
        //get cv attachments list & prevous employment list 
        return _mapper.Map<ForeignAgentHRPoolDto>(foregnAgentCvs);
    }
}
