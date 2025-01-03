using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts.Queries.DTOs;
using Havalan.Domain.Posts;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetLatest;
public class GetLatestPostsQueryHandler : IRequestHandler<GetLatestPostsQuery, List<PostDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetLatestPostsQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetLatestPostsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var post = await _postRepository.GetLatestPosts();
            Check(post);

            var posts = _mapper.Map<List<PostDto>>(post);
            return posts;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }

    private void Check(List<Post> post)
    {
        if (post is null)
            throw new ArgumentNullException(nameof(post));
    }
}