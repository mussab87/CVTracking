using MediatR;

namespace App.Application.Features.MartialStatus.Queries.GetMartialStatusList { }
public class GetMartialStatusListQuery : IRequest<List<MartialStatusDto>>
{
}
