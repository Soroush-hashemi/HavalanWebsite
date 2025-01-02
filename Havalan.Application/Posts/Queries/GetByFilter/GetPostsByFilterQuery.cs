using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetByFilter;
public class GetPostsByFilterQuery : IRequest<PostFilterDto>
{
    public GetPostsByFilterQuery(int pageCount, List<PostDto> posts, PostFilterParams filterParams)
    {
        PageCount = pageCount;
        Posts = posts;
        FilterParams = filterParams;
    }

    public int PageCount { get; set; }
    public List<PostDto> Posts { get; set; }
    public PostFilterParams FilterParams { get; set; }
}