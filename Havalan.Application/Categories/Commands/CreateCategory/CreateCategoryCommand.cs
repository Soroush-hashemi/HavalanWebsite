using Havalan.Domain.Categories;
using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Categories.Commands.CreateCategory;
public record CreateCategoryCommand(string Title,
    string Slug) : IRequest<OperationResult>;