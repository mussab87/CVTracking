using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.Country.Commands.DeleteCountry { }

public class DeleteCountryHandler : IRequestHandler<DeleteCountryRequest>
{
    readonly ICountryRepository _countryRepository;
    readonly IMapper _mapper;

    public DeleteCountryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Handle(DeleteCountryRequest request, CancellationToken cancellationToken)
    {
        var countryToDelete = await _countryRepository.GetByIdAsync(request.Id);
        if (countryToDelete == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        countryToDelete.Status = false;
        await _countryRepository.UpdateAsync(countryToDelete);

        return;
    }
}

