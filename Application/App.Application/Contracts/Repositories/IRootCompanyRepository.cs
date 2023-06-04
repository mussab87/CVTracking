
namespace App.Application.Contracts.Repositories { }
public interface IRootCompanyRepository : IAsyncRepository<RootCompany>
{
    Task<int> AddUserToRootCompany(string applicationUserId, int rootCompanyId);
}

