namespace App.Helper.Dto { }

    public class UserRootCompanyDto
    {
    public UserRootCompanyDto()
    {
        ApplicationUser = new();
    }
    public RootCompany RootCompany { get; set; }

    public List<ApplicationUser> ApplicationUser { get; set; }
}

