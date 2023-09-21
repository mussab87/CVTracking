using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.ForeignAgent.Commands.UpdateForeignAgent { }
public class UpdateForeignAgentRequest : IRequest
{
    public int Id { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    [Required(ErrorMessage = "Foreign Agent Name Field Required")]
    //[Display(Name = "Foreign Agent Name")]
    public string ForeignAgentName { get; set; }
    //[Display(Name = "Foreign Agent License Number")]
    public string ForeignAgentLicenseNumber { get; set; }
    //[Display(Name = "Foreign Agent City")]
    public int? ForeignAgentCountryCityId { get; set; }
    public City ForeignAgentCountryCity { get; set; }
    //[Display(Name = "Foreign Agent Address")]
    public string ForeignAgentAddress { get; set; }
    //[Display(Name = "Foreign Agent Logo")]
    public string ForeignAgentLogo { get; set; }
    //[Display(Name = "Foreign Agent Contact")]
    public string ForeignAgentContacts { get; set; }
    //[Display(Name = "Foreign Agent Notes")]
    public string ForeignAgentComments { get; set; }

    public int RootCompanyId { get; set; }
}

