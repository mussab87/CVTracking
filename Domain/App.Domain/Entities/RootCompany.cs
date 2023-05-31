
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class RootCompany : EntityBase
{
    public string RootCompanyName { get; set; }
    public int? RootCompanyCountryCityId { get; set; }
    [ForeignKey("RootCompanyCountryCityId")]
    public City RootCompanyCountryCity { get; set; }
    public string RootCompanyAddress { get; set; }
    public string RootCompanyEmail { get; set; }
    public string RootCompanyLogo { get; set; }
    public string RootCompanyContacts { get; set; }
    public string RootCompanyComments { get; set; }

    public bool? RootCompanyStatus { get; set; }

}

