using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Users;
using Havalan.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Havalan.Infrastructure.Users.Persistence;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(HavalanDbContext context, IUnitOfWork unitOfWork) 
        : base(context, unitOfWork)
    {
    }

    public Task<User?> GetByUserName(string userName)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public Task<List<User>> GetList()
    {
        return _context.Users.OrderByDescending(d => d.CreationDate).ToListAsync();
    }
}