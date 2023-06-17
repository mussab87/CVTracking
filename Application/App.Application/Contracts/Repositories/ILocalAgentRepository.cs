
namespace App.Application.Contracts.Repositories { }
public interface ILocalAgentRepository : IAsyncRepository<LocalAgent>
{
    Task AddRootCompanyLocalAgent(RootCompanyLocalAgent rootLocalAgent);
    Task<List<LocalAgent>> GetLocalAgentByRootCompanyId(int rootCompanyId);

    Task<List<HRPool>> GetAllLocalAgentCvList(int LocalAgentId);
}

