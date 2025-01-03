using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts.Queries.DTOs;
using Havalan.Application.Posts.Queries.GetIsFeatured;
using Havalan.Domain.Posts;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetIsSidebar;
public class GetIsSidebarPostQueryHandler : IRequestHandler<GetIsSidebarPostQuery, List<PostDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetIsSidebarPostQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetIsSidebarPostQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var posts = await _postRepository.GetIsSidebarPost();
            Check(posts);

            var post = _mapper.Map<List<PostDto>>(posts);
            return post;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }

    private void Check(List<Post> post)
    {
        if (post is null)
            throw new ArgumentNullException();
    }
}