using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.City.Commands.AddCity { }

public class AddCityRequest : IRequest<int>
{
    public int Id { get; protected set; }
    [Required(ErrorMessage = "City Name English Field Required")]
    //[Display(Name = "City Name English")]
    public string NameEnglish { get; set; }
    //[Display(Name = "City Name Arabic")]
    public string NameArabic { get; set; }
    //[Display(Name = "")]
    public bool? Status { get; set; }
    //[Display(Name = "Country")]
    public int CountryCityId { get; set; }
    public string CreatedById { get; set; }
    public DateTime? CreatedDate { get; set; }
}

