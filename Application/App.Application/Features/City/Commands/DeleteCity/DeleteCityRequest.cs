using MediatR;

namespace App.Application.Features.Country.Commands.DeleteCity { }
public class DeleteCityRequest : IRequest
{
    public int Id { get; set; }
}

