
using System.Diagnostics.Metrics;

namespace App.Helper.Dto { }
public class CountriesDto
{
    public int Id { get; protected set; }
    public string NameEnglish { get; set; }
    public string NameArabic { get; set; }
    public bool? Status { get; set; }
}

