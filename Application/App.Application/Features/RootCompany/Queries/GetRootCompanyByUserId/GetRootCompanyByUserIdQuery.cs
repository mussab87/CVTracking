
using MediatR;

namespace App.Application.Features.RootCompany.Queries.GetRootCompanyByUserId;
public class GetRootCompanyByUserIdQuery : IRequest<RootCompanyDto>
{
    public string userId { get; set; }
}

