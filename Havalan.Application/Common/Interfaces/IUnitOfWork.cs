namespace Havalan.Application.Common.Interfaces;
public interface IUnitOfWork
{
    Task CommitChangesAsync();
}