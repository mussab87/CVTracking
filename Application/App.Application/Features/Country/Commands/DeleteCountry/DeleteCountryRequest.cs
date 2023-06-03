using MediatR;

namespace App.Application.Features.Country.Commands.DeleteCountry { }
public class DeleteCountryRequest : IRequest
{
    public int Id { get; set; }
}

