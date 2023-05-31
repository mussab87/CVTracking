
using MediatR;

namespace App.Application.Features.RootCompany.Queries.GetRootCompanyList { }
public class GetRootCompanyQuery : IRequest<List<RootCompanyDto>>
{
    public GetRootCompanyQuery()
    {
    }
}

