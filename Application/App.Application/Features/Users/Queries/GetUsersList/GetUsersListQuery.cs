using MediatR;

namespace App.Application.Features.Users.Queries.GetUsersList { }

public class GetUsersListQuery : IRequest<List<ApplicationUser>>
{
    public GetUsersListQuery()
    {
    }
}

