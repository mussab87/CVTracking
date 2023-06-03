using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.Country.Commands.UpdateCountry { }

public class UpdateCountryRequest : IRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name English Field Required")]
    [Display(Name = "Country Name English")]
    public string NameEnglish { get; set; }

    [Display(Name = "Country Name Arabic")]
    public string? NameArabic { get; set; }

    [Display(Name = "Country Status")]
    public bool? Status { get; set; }

    public string? CreatedById { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}

