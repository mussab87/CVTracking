using AutoMapper;
using MediatR;

namespace App.Application.Features.CancelReason.Queries.GetCancelReasonList { }
public class GetCancelReasonListQueryHandler : IRequestHandler<GetCancelReasonListQuery, List<CancelReasonDto>>
{
    private readonly ICancelReasonRepository _unitOfWork;
    private readonly IMapper _mapper;

    public GetCancelReasonListQueryHandler(ICancelReasonRepository unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<CancelReasonDto>> Handle(GetCancelReasonListQuery request,
            CancellationToken cancellationToken)
    {
        var CancelReasonList = await _unitOfWork.GetAllAsync();
        return _mapper.Map<List<CancelReasonDto>>(CancelReasonList.ToList());
    }
}

