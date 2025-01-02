using Havalan.Application.Common;

namespace Havalan.Application.Posts.Queries.DTOs;
public class PostFilterDto : BasePagination
{
    public List<PostDto> Posts { get; set; } = null!;
    public PostFilterParams FilterParams { get; set; } = null!;
}