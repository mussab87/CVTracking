
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class City : CountryCityBase
{
    public Country CountryCity { get; set; }
}

