
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class LocalAgent : EntityBase
{
    public string LocalAgentName { get; set; }
    public string LocalAgentLicenseNumber { get; set; }
    public int? LocalAgentCountryCityId { get; set; }
    [ForeignKey("LocalAgentCountryCityId")]
    public City LocalAgentCountryCity { get; set; }
    public string LocalAgentAddress { get; set; }
    public string LocalAgentLogo { get; set; }
    public string LocalAgentContacts { get; set; }
    public string LocalAgentComments { get; set; }
}

