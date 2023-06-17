using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.LocalAgent.Commands.AddLocalAgent { }

public class AddLocalAgentRequest : IRequest<int>
{
    public string CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    [Required(ErrorMessage = "Local Agent Name English Field Required")]
    [Display(Name = "Local Agent Name English")]
    public string LocalAgentNameEnglish { get; set; }
    [Display(Name = "Local Agent Name Arabic")]
    public string LocalAgentNameArabic { get; set; }
    [Display(Name = "Local Agent License Number")]
    public string LocalAgentLicenseNumber { get; set; }
    [Display(Name = "Local Agent City")]
    public int? LocalAgentCountryCityId { get; set; }
    [Display(Name = "Local Agent Address")]
    public string LocalAgentAddress { get; set; }
    [Display(Name = "Local Agent Logo")]
    public string LocalAgentLogo { get; set; }
    [Display(Name = "Local Agent Contact")]
    public string LocalAgentContacts { get; set; }
    [Display(Name = "Local Agent Notes")]
    public string LocalAgentComments { get; set; }

    public int RootCompanyId { get; set; }
}

