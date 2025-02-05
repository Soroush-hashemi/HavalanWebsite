using Havalan.Application.Categories.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetById;
public record GetCategoryByIdQuery(long CategoryId) : IRequest<CategoryDto>;