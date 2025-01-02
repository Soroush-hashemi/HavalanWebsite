using Havalan.Application.Common;

namespace Havalan.Application.Posts.Queries.DTOs;
public class PostDto : BaseDto
{
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageName { get; set; } = null!;
    public int View { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsSidebar { get; set; }
}