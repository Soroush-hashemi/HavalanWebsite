using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Posts.Commands.Delete;
public record DeletePostCommand(long PostId) : IRequest<OperationResult>;