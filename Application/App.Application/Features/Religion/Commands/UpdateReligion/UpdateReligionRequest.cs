using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.Religion.Commands.UpdateReligion { }

public class UpdateReligionRequest : IRequest
{
    public int Id { get; set; }
    public string NameEnglish { get; set; }
    public string NameArabic { get; set; }
    public bool? Status { get; set; }
    public int CountryCityId { get; set; }

    public string? CreatedById { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? LastModifiedById { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}

