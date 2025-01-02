namespace Havalan.Application.Posts.Queries.DTOs;
public class PostFilterParams
{
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public int PageId { get; set; }
    public int Take { get; set; }
}