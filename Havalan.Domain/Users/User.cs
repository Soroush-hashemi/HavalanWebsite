using Havalan.Domain.Base;
using Havalan.Domain.Common;

namespace Havalan.Domain.Users;
public class User : BaseEntity
{
    private User() { }

    public string UserName { get; private set; }
    public string FullName { get; private set; }
    public string Password { get; private set; }
    public UserRole Roles { get; private set; }

    public User(string userName, string fullName,
        string password, IUserDomainService userDomainService)
    {
        CheckInput(userName, userDomainService);
        UserName = userName;
        FullName = fullName;
        Password = password;
        Roles = UserRole.user;
    }

    public void Edit(string userName, string fullName,
        IUserDomainService userDomainService)
    {
        CheckInput(userName, userDomainService);
        UserName = userName;
        FullName = fullName;
    }

    public void CheckInput(string userName, IUserDomainService userDomainService)
    {
        if (UserName != userName)
        {
            var result = userDomainService.IsUserNameExist(userName);
            if (result.Status != OperationResultStatus.Success)
                throw new NullOrEmptyException(result.Message);
        }
    }
}