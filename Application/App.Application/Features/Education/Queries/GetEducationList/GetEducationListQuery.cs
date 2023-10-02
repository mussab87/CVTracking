using MediatR;

namespace App.Application.Features.Education.Queries.GetEducationList { }
public class GetEducationListQuery : IRequest<List<EducationDto>>
{
}
