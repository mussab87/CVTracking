using MediatR;

namespace App.Application.Features.UserRootCompany.Queries.GetUserRootCompanyList { }

    public class GetUserRootCompanyListQuery : IRequest<List<UserRootCompanyDto>>
    {
    public GetUserRootCompanyListQuery()
    {
        
    }
}

