
namespace App.Application.Contracts.Repositories { }
public interface IForeignAgentRepository : IAsyncRepository<ForeignAgent>
{
    Task AddRootCompanyForeignAgent(RootCompanyForeignAgent rootForeignAgent);
    Task<List<ForeignAgent>> GetForeignAgentByRootCompanyId(int rootCompanyId);

    Task<List<HRPool>> GetAllForeignAgentCvList(int ForeignAgentId);
}

