using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Users.Commands.Login;
public record LoginCommand(string userName, string fullName,
        string password) : IRequest<OperationResult>;