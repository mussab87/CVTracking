using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.Religion.Commands.AddReligion { }

public class AddReligionHandler : IRequestHandler<AddReligionRequest, int>
{
    readonly IReligionRepository _unitOfWork;
    readonly IMapper mapper;

    public AddReligionHandler(IReligionRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;

    }

    public async Task<int> Handle(AddReligionRequest request, CancellationToken cancellationToken)
    {
        var newReligion = await _unitOfWork.AddAsync(mapper.Map<Religion>(request));

        return newReligion.Id;
    }
}

