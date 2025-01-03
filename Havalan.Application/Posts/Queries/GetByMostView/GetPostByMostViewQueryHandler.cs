using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts.Queries.DTOs;
using Havalan.Domain.Posts;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetByMostView;
public class GetPostByMostViewQueryHandler : IRequestHandler<GetPostByMostViewQuery, List<PostDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetPostByMostViewQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetPostByMostViewQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var PostsWithMostView = await _postRepository.GetPostWithMostView();
            Check(PostsWithMostView);

            var PostsDto = _mapper.Map<List<PostDto>>(PostsWithMostView);
            return PostsDto;
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