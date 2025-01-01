using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Categories.Commands.AddSubCategory;
public record AddSubCategoryCommand(long parentId, string title, string slug) : IRequest<OperationResult>;