using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Posts;
using Havalan.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Havalan.Infrastructure.Posts.Persistence;
public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(HavalanDbContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
    }

    public void DeletePost(Post post)
    {
        _context.Posts.Remove(post);
    }

    public IEnumerable<Post> GetAllPostAsEnumerable()
    {
        return _context.Posts.OrderByDescending(d => d.CreationDate).ToList();
    }

    public Task<List<Post>> GetAllPostAsList()
    {
        return _context.Posts.ToListAsync();
    }

    public Task<Post?> GetIsFeaturedPost()
    {
        return _context.Posts.OrderByDescending(d => d.CreationDate)
            .FirstOrDefaultAsync(t => t.IsFeatured == true);
    }

    public Task<List<Post>> GetIsSidebarPost()
    {
        return _context.Posts.OrderByDescending(d => d.CreationDate)
            .Where(s => s.IsSidebar == true).ToListAsync();
    }

    public Task<List<Post>> GetLatestPosts()
    {
        return _context.Posts.OrderByDescending(d => d.CreationDate).ToListAsync();
    }

    public Task<Post?> GetPostBySlug(string slug)
    {
        return _context.Posts.FirstOrDefaultAsync(s => s.Slug == slug);
    }

    public Task<List<Post>> GetPostWithMostView()
    {
        return _context.Posts.OrderBy(v => v.View).ToListAsync();
    }
}