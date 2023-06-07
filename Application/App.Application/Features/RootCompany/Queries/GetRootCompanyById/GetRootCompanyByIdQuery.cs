
using MediatR;

namespace App.Application.Features.RootCompany.Queries.GetRootCompanyById;
public class GetRootCompanyByIdQuery : IRequest<RootCompanyDto>
{
    public int RootCompanyId { get; set; }
}

