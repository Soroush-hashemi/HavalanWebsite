using Havalan.Domain.Posts;

namespace Havalan.Application.Common.Interfaces;
public interface IPostRepository :IBaseRepository<Post>
{
    void DeletePost(Post post);
    IEnumerable<Post> GetAllPostAsEnumerable();
    Task<List<Post>> GetAllPostAsList();
    Task<Post> GetIsFeaturedPost();
    Task<List<Post>> GetIsSidebarPost();
    Task<List<Post>> GetLatestPosts();
    Task<Post> GetPostBySlug(string slug);
    Task<List<Post>> GetPostWithMostView();
}