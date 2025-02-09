using Havalan.Application.TrendingNews.Queries.DTO;
using MediatR;

namespace Havalan.Application.TrendingNews.Queries.GetById;
public record GetByIdNewsQuery(long Id) : IRequest<TrendingNewDto>;