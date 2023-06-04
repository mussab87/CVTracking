using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.RootCompany.Commands.AddRootCompany { }

public class AddRootCompanyHandler : IRequestHandler<AddRootCompanyRequest, int>
{
    readonly IRootCompanyRepository _rootCompanyRepository;
    readonly IMapper mapper;

    public AddRootCompanyHandler(IRootCompanyRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger)
    {
        _rootCompanyRepository = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.mapper = mapper;

    }

    public async Task<int> Handle(AddRootCompanyRequest request, CancellationToken cancellationToken)
    {
        var newRootCompany = await _rootCompanyRepository.AddAsync(mapper.Map<RootCompany>(request));

        return newRootCompany.Id;
    }
}

