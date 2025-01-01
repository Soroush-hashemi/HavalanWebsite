using Havalan.Domain.Common;

namespace Havalan.Domain.Users;
public interface IUserDomainService
{
    public OperationResult IsUserNameExist(string userName);
}