
namespace App.Application.Contracts.Repositories { }

public interface ICandidateSkillsRepository : IAsyncRepository<CandidateSkills>
{
    Task<List<CVCandidateSkills>> GetCVCandidateSkills(int cvId);
    Task AddCVCandidateSkills(CV cv, int[] skils, string foreugnUserId);
}

