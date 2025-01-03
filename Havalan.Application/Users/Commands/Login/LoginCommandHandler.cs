using Havalan.Application.Common;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Users;
using MediatR;

namespace Havalan.Application.Users.Commands.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, OperationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _userDomainService;
    public LoginCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
    {
        _userRepository = userRepository;
        _userDomainService = userDomainService;
    }

    public async Task<OperationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var password = Hasher.Hash(request.password);

            var user = new User(request.userName, 
                request.fullName, password, _userDomainService);

            _userRepository.Add(user);
            await _userRepository.Save();

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    public void Check(User user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user));
    }
}