using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Comments.Commands.Delete;
public record DeleteCommentsCommand(long commentId) : IRequest<OperationResult>;