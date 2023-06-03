
using System.Diagnostics.Metrics;

namespace App.Application.Features.City.Queries.GetCountriesList { }

public class CityDto
{
    public int Id { get; set; }
    public string NameEnglish { get; set; }
    public string NameArabic { get; set; }
    public bool? Status { get; set; }
    public string? CreatedById { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public int CountryCityId { get; set; }
    public Country CountryCity { get; set; }
}

