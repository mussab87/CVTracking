using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.LocalAgent.Commands.UpdateLocalSelectedCvSponsorData { }

public class UpdateLocalSelectedCvSponsorDataRequest : IRequest<int>
{
    public int LocalAgentId { get; set; }
    public int HRPoolId { get; set; }
    public string CreatedById { get; set; }

    public string sponsorName { get; set; }
    public string sponsorIDNumber { get; set; }
    public string sponsorVisaNumber { get; set; }
    public string sponsorContact { get; set; }
    public DateTime? SponsorDateOfBirth { get; set; }
}

