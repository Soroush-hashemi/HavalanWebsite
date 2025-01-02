using Havalan.Application.Categories.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetBySlug;
public record GetBySlugQuery(string Slug) : IRequest<CategoryDto>;