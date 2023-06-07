using AutoMapper;
using MediatR;

namespace App.Application.Features.RootCompany.Queries.GetRootCompanyById;

public class GetRootCompanyByIdHandler : IRequestHandler<GetRootCompanyByIdQuery, RootCompanyDto>
{
    private readonly IRootCompanyRepository _unitOfWork;

    private readonly IMapper _mapper;

    public GetRootCompanyByIdHandler(IRootCompanyRepository userRootCompanyRepository, IMapper mapper)
    {
        _unitOfWork = userRootCompanyRepository ?? throw new ArgumentNullException(nameof(userRootCompanyRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    public async Task<RootCompanyDto> Handle(GetRootCompanyByIdQuery request,
           CancellationToken cancellationToken)
    {
        //get RootCompanyUser
        var rootCompany = await _unitOfWork.GetByIdAsync(request.RootCompanyId);

        return _mapper.Map<RootCompanyDto>(rootCompany);
    }
}

