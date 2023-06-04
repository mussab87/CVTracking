using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.UserRootCompany.Commands.AddUserToRootCompany { }

public class AddUserToRootCompanyHandler : IRequestHandler<AddUserToRootCompanyRequest, int>
{
    readonly IRootCompanyRepository _rootCompanyRepository;
    readonly IMapper mapper;

    public AddUserToRootCompanyHandler(IRootCompanyRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger)
    {
        _rootCompanyRepository = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.mapper = mapper;

    }

    public async Task<int> Handle(AddUserToRootCompanyRequest request, CancellationToken cancellationToken)
    {
        var newRootCompany = await _rootCompanyRepository.AddUserToRootCompany(request.ApplicationUserId, request.RootCompanyId);

        return newRootCompany;
    }
}

