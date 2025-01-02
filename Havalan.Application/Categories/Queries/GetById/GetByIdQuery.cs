using Havalan.Application.Categories.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetById;
public record GetByIdQuery(long CategoryId) : IRequest<CategoryDto>;