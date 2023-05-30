namespace App.Application.Contracts.Repositories { }

public interface IUserRepository
{
    Task<IEnumerable<ApplicationUser>> GetAllUsers();
}

