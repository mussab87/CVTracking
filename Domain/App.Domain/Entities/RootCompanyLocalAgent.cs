
namespace App.Domain.Entities { }

public class RootCompanyLocalAgent
{
    public int RootCompanyId { get; set; }
    public RootCompany RootCompany { get; set; }

    public int LocalAgentId { get; set; }
    public LocalAgent LocalAgent { get; set; }
}

