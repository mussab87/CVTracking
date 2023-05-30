
namespace App.Domain.Entities { }

public class RootCompanyForeignAgent
{
    public int RootCompanyId { get; set; }
    public RootCompany RootCompany { get; set; }

    public int ForeignAgentId { get; set; }
    public ForeignAgent ForeignAgent { get; set; }
}

