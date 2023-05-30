
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class ForeignAgent : EntityBase
{
    public string ForeignAgentName { get; set; }
    public string ForeignAgentLicenseNumber { get; set; }
    public int? ForeignAgentCountryCityId { get; set; }
    [ForeignKey("ForeignAgentCountryCityId")]
    public City ForeignAgentCountryCity { get; set; }
    public string ForeignAgentAddress { get; set; }
    public string ForeignAgentLogo { get; set; }
    public string ForeignAgentContacts { get; set; }
    public string ForeignAgentComments { get; set; }

}

