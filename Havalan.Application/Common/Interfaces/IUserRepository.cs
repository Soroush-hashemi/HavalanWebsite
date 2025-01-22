using Havalan.Domain.Users;

namespace Havalan.Application.Common.Interfaces;
public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUserName(string userName);
    Task<List<User>> GetList();
}