using MediatR;

namespace App.Application.Features.Religion.Queries.GetReligionList { }
public class GetReligionListQuery : IRequest<List<ReligionDto>>
{
}
