using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.ForeignAgent.Commands.AddForeignAgent { }

public class AddForeignAgentRequestHandler : IRequestHandler<AddForeignAgentRequest, int>
{
    readonly IForeignAgentRepository _unitOfWork;
    readonly IMapper mapper;

    public AddForeignAgentRequestHandler(IForeignAgentRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.mapper = mapper;

    }

    public async Task<int> Handle(AddForeignAgentRequest request, CancellationToken cancellationToken)
    {
        var newForeignAgent = await _unitOfWork.AddAsync(mapper.Map<ForeignAgent>(request));

        //add RootCompanyForeignAgent
        var rootCompanyForeignAgent = new RootCompanyForeignAgent()
        { ForeignAgentId = newForeignAgent.Id, RootCompanyId = request.RootCompanyId };

        await _unitOfWork.AddRootCompanyForeignAgent(rootCompanyForeignAgent);
        return newForeignAgent.Id;
    }
}

