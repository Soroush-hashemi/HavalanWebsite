using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Users;

namespace Havalan.Application.Users;
public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _userRepository;
    public UserDomainService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public OperationResult IsUserNameExist(string userName)
    {
        var Exists = _userRepository.Exists(u => u.UserName == userName);
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("userName تکراری است");
    }
}