
using AutoMapper;
using MediatR;

namespace App.Application.Features.RootCompany.Queries.GetRootCompanyList { }
public class GetRootCompanyQueryHandler : IRequestHandler<GetRootCompanyQuery, List<RootCompanyDto>>
{
    private readonly IRootCompanyRepository _rootCompany;
    private readonly IMapper _mapper;

    public GetRootCompanyQueryHandler(IRootCompanyRepository rootCompany, IMapper mapper)
    {
        _rootCompany = rootCompany ?? throw new ArgumentNullException(nameof(rootCompany));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<RootCompanyDto>> Handle(GetRootCompanyQuery request,
            CancellationToken cancellationToken)
    {
        var rootCompanyList = await _rootCompany.GetAsync(null, null, "RootCompanyCountry", true);
        return _mapper.Map<List<RootCompanyDto>>(rootCompanyList);
    }
}

