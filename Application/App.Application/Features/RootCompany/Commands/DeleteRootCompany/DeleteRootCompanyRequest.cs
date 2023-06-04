using MediatR;

namespace App.Application.Features.RootCompany.Commands.DeleteRootCompany { }
public class DeleteRootCompanyRequest : IRequest
{
    public int Id { get; set; }
}

