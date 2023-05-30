
namespace App.Domain.Entities { }

public class RootCompanyUsers
{
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int RootCompanyId { get; set; }
    public RootCompany RootCompany { get; set; }
}

