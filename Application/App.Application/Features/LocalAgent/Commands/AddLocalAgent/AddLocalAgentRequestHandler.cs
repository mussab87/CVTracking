using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.LocalAgent.Commands.AddLocalAgent { }

public class AddLocalAgentRequestHandler : IRequestHandler<AddLocalAgentRequest, int>
{
    readonly ILocalAgentRepository _unitOfWork;
    readonly IMapper mapper;

    public AddLocalAgentRequestHandler(ILocalAgentRepository unitOfWork, IMapper mapper,
        ILogger<AddCountryHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.mapper = mapper;

    }

    public async Task<int> Handle(AddLocalAgentRequest request, CancellationToken cancellationToken)
    {
        var newLocalAgent = await _unitOfWork.AddAsync(mapper.Map<LocalAgent>(request));

        //add RootCompanyLocalAgent
        var rootCompanyLocalAgent = new RootCompanyLocalAgent()
        { LocalAgentId = newLocalAgent.Id, RootCompanyId = request.RootCompanyId };

        await _unitOfWork.AddRootCompanyLocalAgent(rootCompanyLocalAgent);
        return newLocalAgent.Id;
    }
}

