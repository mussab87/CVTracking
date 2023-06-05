using AutoMapper;
using MediatR;

namespace App.Application.Features.UserRootCompany.Queries.GetUserRootCompanyList { }

public class GetUserRootCompanyListQueryHandler : IRequestHandler<GetUserRootCompanyListQuery, List<UserRootCompanyDto>>
{
    private readonly IUserRootCompanyRepository _unitOfWork;

    private readonly IMapper _mapper;

    public GetUserRootCompanyListQueryHandler(IUserRootCompanyRepository userRootCompanyRepository, IMapper mapper)
    {
        _unitOfWork = userRootCompanyRepository ?? throw new ArgumentNullException(nameof(userRootCompanyRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        
    }

    public async Task<List<UserRootCompanyDto>> Handle(GetUserRootCompanyListQuery request,
            CancellationToken cancellationToken)
    {
        //get all rootCompany
        List<UserRootCompanyDto> userCompanyDto = await FillData();

        return userCompanyDto;        
    }


    async Task<List<UserRootCompanyDto>> FillData()
    {
        var rootCompanies = await _unitOfWork.GetAsync(null, null, "RootCompanyCountry", true);

        var userCompanyDto = new List<UserRootCompanyDto>();

        foreach (var root in rootCompanies)
        {
            var usersInRoot = await _unitOfWork.GetAllUserInRootCompany(root.Id);

            var userObj = new UserRootCompanyDto();
            userObj.RootCompany = root;
            userObj.ApplicationUser = usersInRoot;

            userCompanyDto.Add(userObj);
        }
        return userCompanyDto;
    }


}

