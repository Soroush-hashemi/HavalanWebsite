using Havalan.Domain.Posts;

namespace Havalan.Application.Common.Interfaces;
public interface IPostRepository :IBaseRepository<Post>
{
    void DeletePost(Post post);
    IEnumerable<Post> GetAllPostAsEnumerable();
}