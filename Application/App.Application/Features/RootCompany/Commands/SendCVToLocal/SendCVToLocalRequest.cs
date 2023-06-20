using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.Application.Features.RootCompany.Commands.SendCVToLocal { }

public class SendCVToLocalRequest : IRequest<bool>
{
    public List<ForeignAgentHRPoolDto> ForeignAgentHRPoolDto { get; set; }
}

