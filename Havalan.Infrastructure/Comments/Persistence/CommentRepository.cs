using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Comments;
using Havalan.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Havalan.Infrastructure.Comments.Persistence;
public class CommentRepository : BaseRepository<Comment>, ICommentsRepository
{

    public CommentRepository(HavalanDbContext dbContext, IUnitOfWork unitOfWork)
        : base(dbContext, unitOfWork)
    {

    }

    public void DeleteComment(Comment comment)
    {
        _context.Remove(comment);
    }

    public List<Comment> GetAllComments()
    {
        return _context.Comments.OrderByDescending(c => c.CreationDate).ToList();
    }

    public async Task<Comment?> GetByPostId(long PostId)
    {
        return await _context.Comments.FirstOrDefaultAsync(p => p.PostId == PostId);
    }

    public string GetPostSlug(long PostId)
    {
        var post = _context.Posts.FirstOrDefault(s => s.Id == PostId);
        return post.Slug;
    }
}