namespace App.Application.Features.ForeignAgent.ForeignAgentDtos { }

public class ForegnAgentDto
{
    public ForegnAgentDto()
    {
        ForeignAgentUsers = new List<ApplicationUser>();
    }
    public int Id { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public string ForeignAgentName { get; set; }
    public string ForeignAgentLicenseNumber { get; set; }
    public int? ForeignAgentCountryCityId { get; set; }
    public City ForeignAgentCountryCity { get; set; }
    public string ForeignAgentAddress { get; set; }
    public string ForeignAgentLogo { get; set; }
    public string ForeignAgentContacts { get; set; }
    public string ForeignAgentComments { get; set; }

    public List<ApplicationUser> ForeignAgentUsers { get; set; }
}

