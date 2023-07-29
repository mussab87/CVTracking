using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.LocalAgent.Commands.DeleteLocalCV { }

public class DeleteLocalCVRequest : IRequest<int>
{
    public int CVId { get; set; }
}

