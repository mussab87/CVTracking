using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.LocalAgent.Commands.UpdateLocalSendByWhatsApp { }

public class UpdateLocalSendByWhatsAppRequest : IRequest<int>
{
    public int LocalAgentId { get; set; }
    public int HRPoolId { get; set; }
    public string CreatedById { get; set; }
}

