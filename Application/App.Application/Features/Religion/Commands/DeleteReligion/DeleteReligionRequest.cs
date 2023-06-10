using MediatR;

namespace App.Application.Features.Religion.Commands.DeleteReligion { }
public class DeleteReligionRequest : IRequest
{
    public int Id { get; set; }
}

