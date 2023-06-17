namespace App.Application.Features.LocalAgent.LocalAgentDtos { }

public class LocalAgentDto
{
    public LocalAgentDto()
    {
        LocalAgentUsers = new List<ApplicationUser>();
    }
    public int Id { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public string LocalAgentNameEnglish { get; set; }
    public string LocalAgentNameArabic { get; set; }
    public string LocalAgentLicenseNumber { get; set; }
    public int? LocalAgentCountryCityId { get; set; }
    public City LocalAgentCountryCity { get; set; }
    public string LocalAgentAddress { get; set; }
    public string LocalAgentLogo { get; set; }
    public string LocalAgentContacts { get; set; }
    public string LocalAgentComments { get; set; }

    public List<ApplicationUser> LocalAgentUsers { get; set; }
}

