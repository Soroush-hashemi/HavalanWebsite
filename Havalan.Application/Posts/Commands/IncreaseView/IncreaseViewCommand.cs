using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Posts.Commands.IncreaseView;
public record IncreaseViewCommand(long postId) : IRequest<OperationResult>;