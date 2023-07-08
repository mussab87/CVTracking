using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Application.Features.ForeignAgent.Queries.GetForeignAgentById { }


public class GetAllCvListQueryHandler : IRequestHandler<GetAllCvListQuery, List<ForeignAgentHRPoolDto>>
{
    private readonly IForeignAgentRepository _unitOfWork;
    readonly ILocalSelectedCVRepository _selectedCv;
    private readonly IMapper _mapper;

    public GetAllCvListQueryHandler(IForeignAgentRepository unitOfWork, IMapper mapper, ILocalSelectedCVRepository selectedCv)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _selectedCv = selectedCv;
    }

    public async Task<List<ForeignAgentHRPoolDto>> Handle(GetAllCvListQuery request,
            CancellationToken cancellationToken)
    {
        var foregnAgentCvs = await _unitOfWork.GetAllForeignAgentCvList(request.ForeignAgentId);
        var result = _mapper.Map<List<ForeignAgentHRPoolDto>>(foregnAgentCvs);

        foreach (var cv in result)
        {
            //get selectedCV
            var selectedCV = await _selectedCv.GetAsync(predicate: c => c.HRPoolId == cv.Id);
            if (selectedCV != null && selectedCV.Count > 0)
            {
                cv.selected = selectedCV[0];
            }
        }

        return result;
    }
}
