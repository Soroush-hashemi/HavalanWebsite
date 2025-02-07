using Havalan.Domain.Comments;

namespace Havalan.Application.Common.Interfaces;
public interface ICommentsRepository : IBaseRepository<Comment>
{
    Task<Comment?> GetByPostId(long PostId);
    List<Comment> GetAllComments();
    void DeleteComment(Comment comment);
    string GetPostSlug(long PostId);
}