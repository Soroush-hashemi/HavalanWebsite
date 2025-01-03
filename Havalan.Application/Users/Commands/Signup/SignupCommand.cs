using Havalan.Domain.Common;
using MediatR;
using System.Security.Claims;

namespace Havalan.Application.Users.Commands.Signup;
public record SignupCommand(string userName, string password)
    : IRequest<OperationResult<ClaimsPrincipal>>;