using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Categories.Commands.Edit;
public record EditCategoryCommand(long CategoryId,string Title, string Slug) : IRequest<OperationResult>;