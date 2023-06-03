using AutoMapper;
using MediatR;

namespace App.Application.Features.Country.Commands.UpdateCountry { }
public class UpdateCountryHandler : IRequestHandler<UpdateCountryRequest>
{
    readonly ICountryRepository _countryRepository;
    readonly IMapper _mapper;

    public UpdateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
    {
        var countryToUpdate = await _countryRepository.GetByIdAsync(request.Id);
        if (countryToUpdate == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        _mapper.Map(request, countryToUpdate, typeof(UpdateCountryRequest), typeof(Country));

        await _countryRepository.UpdateAsync(countryToUpdate);

        return;
    }
}

