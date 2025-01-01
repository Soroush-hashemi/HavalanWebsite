
using Havalan.Application.Categories.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetByParentId;
public record GetSubCategoryByParentId(long ParentId) : IRequest<SubCategoryDto>;