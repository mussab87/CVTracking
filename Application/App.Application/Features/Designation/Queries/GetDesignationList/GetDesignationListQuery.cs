using MediatR;

namespace App.Application.Features.Designation.Queries.GetDesignationList { }
public class GetDesignationListQuery : IRequest<List<DesignationDto>>
{
}
