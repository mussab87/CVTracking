
namespace App.Helper.Dto { }
public class RootCompanyCountDto
{
    public RootCompanyCountDto()
    {
        CountCancel = new List<CountCancelCVDto>();
    }
    public int? UserCount { get; set; }
    public int? FoeignAgentCount { get; set; }
    public int? LocalAgentCount { get; set; }
    public List<CountCancelCVDto> CountCancel { get; set; }
}

