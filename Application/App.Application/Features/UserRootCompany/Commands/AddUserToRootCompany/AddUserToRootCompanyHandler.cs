using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.UserRootCompany.Commands.AddUserToRootCompany { }

public class AddUserToRootCompanyHandler : IRequestHandler<AddUserToRootCompanyRequest, int>
{
    readonly IUserRootCompanyRepository _unitOfWork;
    readonly IMapper mapper;

    public AddUserToRootCompanyHandler(IUserRootCompanyRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.mapper = mapper;

    }

    public async Task<int> Handle(AddUserToRootCompanyRequest request, CancellationToken cancellationToken)
    {
        var newRootCompany = await _unitOfWork.AddUserToRootCompany(request.ApplicationUserId, request.RootCompanyId);

        return newRootCompany;
    }
}

