using Havalan.Application.Categories.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetBySlug;
public record GetBySlug(string Slug) : IRequest<CategoryDto>;