using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.LocalAgent.Commands.AddLocalSelectedCV { }

public class AddLocalSelectedCVRequest : IRequest<int>
{
    public int LocalAgentId { get; set; }
    public int HRPoolId { get; set; }
    public string CreatedById { get; set; }
}

