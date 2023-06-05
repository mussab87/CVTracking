
namespace App.Application.Contracts.Repositories { }
public interface IRootCompanyRepository : IAsyncRepository<RootCompany>
{
    Task<RootCompany> GetRootCompanyByUserId(string userId);
}

