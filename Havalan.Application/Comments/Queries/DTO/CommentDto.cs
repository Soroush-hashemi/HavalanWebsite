using Havalan.Application.Common;

namespace Havalan.Application.Comments.Queries.DTO;
public class CommentDto : BaseDto
{
    public long PostId { get; set; }
    public string PostSlug { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Text { get; set; } = null!;
}