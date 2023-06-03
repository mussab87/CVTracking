using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.Country.Commands.DeleteCity { }

public class DeleteCityHandler : IRequestHandler<DeleteCityRequest>
{
    readonly ICityRepository _cityRepository;
    readonly IMapper _mapper;

    public DeleteCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Handle(DeleteCityRequest request, CancellationToken cancellationToken)
    {
        var cityToDelete = await _cityRepository.GetByIdAsync(request.Id);
        if (cityToDelete == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        cityToDelete.Status = false;
        await _cityRepository.UpdateAsync(cityToDelete);

        return;
    }
}

