using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Categories.Commands.Delete;
public record DeleteCategoryCommand(long CategoryId) : IRequest<OperationResult>;