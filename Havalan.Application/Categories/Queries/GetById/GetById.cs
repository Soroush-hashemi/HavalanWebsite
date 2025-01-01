using Havalan.Application.Categories.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetById;
public record GetById(long CategoryId) : IRequest<CategoryDto>;