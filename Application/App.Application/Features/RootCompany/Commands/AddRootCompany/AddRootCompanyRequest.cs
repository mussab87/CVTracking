using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.RootCompany.Commands.AddRootCompany { }

public class AddRootCompanyRequest : IRequest<int>
{
    public string CreatedById { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    [Required(ErrorMessage = "Root Company Name Field Required")]
    //[Remote(action: "IsUsernameInUse", controller: "SuperAdmin")]
    [Display(Name = "Root Company Name")]
    public string? RootCompanyName { get; set; }

    [Required(ErrorMessage = "Root Company Country Field Required")]
    [Display(Name = "Root Company Country")]
    public int? RootCompanyCountryId { get; set; }

    [Display(Name = "Root Company Address")]
    public string? RootCompanyAddress { get; set; }

    [Display(Name = "Root Company Email")]
    public string? RootCompanyEmail { get; set; }

    [Display(Name = "Root Company Logo")]
    public string RootCompanyLogo { get; set; }

    [Required(ErrorMessage = "Root Company Contact Field Required")]
    [Display(Name = "Root Company Contact")]
    public string RootCompanyContacts { get; set; }

    [Display(Name = "Root Company Note")]
    public string RootCompanyComments { get; set; }

    [Required(ErrorMessage = "Root Company Status Field Required")]
    [Display(Name = "Root Company Status")]
    public bool? RootCompanyStatus { get; set; }
}

