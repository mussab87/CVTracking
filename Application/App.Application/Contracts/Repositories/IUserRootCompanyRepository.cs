namespace App.Application.Contracts.Repositories { }

public interface IUserRootCompanyRepository : IAsyncRepository<RootCompany>
{
    Task<int> AddUserToRootCompany(string applicationUserId, int rootCompanyId);

    Task<List<ApplicationUser>> GetAllUserInRootCompany(int rootCompanyId);
}

