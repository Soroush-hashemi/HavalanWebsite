using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Comments.Commands.Create;
public record CreateCommentsCommand(long PostId, string UserName, string Text) : IRequest<OperationResult>;