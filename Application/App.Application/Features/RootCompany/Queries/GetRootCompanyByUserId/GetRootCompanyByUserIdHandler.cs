
using AutoMapper;
using MediatR;

namespace App.Application.Features.RootCompany.Queries.GetRootCompanyByUserId;

public class GetRootCompanyByUserIdHandler : IRequestHandler<GetRootCompanyByUserIdQuery, RootCompanyDto>
{
    private readonly IRootCompanyRepository _unitOfWork;

    private readonly IMapper _mapper;

    public GetRootCompanyByUserIdHandler(IRootCompanyRepository userRootCompanyRepository, IMapper mapper)
    {
        _unitOfWork = userRootCompanyRepository ?? throw new ArgumentNullException(nameof(userRootCompanyRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    public async Task<RootCompanyDto> Handle(GetRootCompanyByUserIdQuery request,
           CancellationToken cancellationToken)
    {
        //get RootCompanyUser
        var rootCompany = await _unitOfWork.GetRootCompanyByUserId(request.userId);

        return _mapper.Map<RootCompanyDto>(rootCompany);
    }
}

