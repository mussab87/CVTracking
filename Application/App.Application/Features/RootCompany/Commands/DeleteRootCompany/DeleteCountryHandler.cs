using AutoMapper;
using MediatR;

namespace App.Application.Features.RootCompany.Commands.DeleteRootCompany { }

public class DeleteRootCompanyHandler : IRequestHandler<DeleteRootCompanyRequest>
{
    readonly IRootCompanyRepository _rootCompanyRepository;
    readonly IMapper _mapper;

    public DeleteRootCompanyHandler(IRootCompanyRepository unitOfWork, IMapper mapper)
    {
        _rootCompanyRepository = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Handle(DeleteRootCompanyRequest request, CancellationToken cancellationToken)
    {
        var rootCompanyToDelete = await _rootCompanyRepository.GetByIdAsync(request.Id);
        if (rootCompanyToDelete == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        rootCompanyToDelete.RootCompanyStatus = false;
        await _rootCompanyRepository.UpdateAsync(rootCompanyToDelete);

        return;
    }
}

