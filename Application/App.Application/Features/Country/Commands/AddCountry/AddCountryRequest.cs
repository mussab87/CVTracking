using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.Country.Commands.AddCountry { }

public class AddCountryRequest : IRequest<int>
{
    public required string NameEnglish { get; set; }
    public string NameArabic { get; set; }
    public bool? Status { get; set; }
    public string CreatedById { get; set; }
    public DateTime? CreatedDate { get; set; }
}

