using Havalan.Application.TrendingNews.Queries.DTO;
using MediatR;

namespace Havalan.Application.TrendingNews.Queries.GetList;
public record GetListOfNewsQuery : IRequest<List<TrendingNewDto>>;