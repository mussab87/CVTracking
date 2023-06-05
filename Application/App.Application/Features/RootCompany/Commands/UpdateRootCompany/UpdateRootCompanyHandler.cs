using AutoMapper;
using MediatR;

namespace App.Application.Features.Country.Commands.UpdateRootCompany { }
public class UpdateRootCompanyHandler : IRequestHandler<UpdateRootCompanyRequest>
{
    readonly IRootCompanyRepository _rootCompanyRepository;
    readonly IMapper _mapper;

    public UpdateRootCompanyHandler(IRootCompanyRepository unitOfWork, IMapper mapper)
    {
        _rootCompanyRepository = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper;
    }

    public async Task Handle(UpdateRootCompanyRequest request, CancellationToken cancellationToken)
    {
        var rootCompanyToUpdate = await _rootCompanyRepository.GetByIdAsync(request.Id);
        if (rootCompanyToUpdate == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        _mapper.Map(request, rootCompanyToUpdate, typeof(UpdateRootCompanyRequest), typeof(RootCompany));

        await _rootCompanyRepository.UpdateAsync(rootCompanyToUpdate);

        return;
    }
}

