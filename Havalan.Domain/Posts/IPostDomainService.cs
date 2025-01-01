using Havalan.Domain.Common;

namespace Havalan.Domain.Posts;
public interface IPostDomainService
{
    public OperationResult IsSlugExist(string slug);
}