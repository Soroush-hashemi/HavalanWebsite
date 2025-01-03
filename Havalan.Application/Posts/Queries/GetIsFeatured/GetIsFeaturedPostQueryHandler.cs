using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts.Queries.DTOs;
using Havalan.Domain.Posts;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetIsFeatured;
public class GetIsFeaturedPostQueryHandler : IRequestHandler<GetIsFeaturedPostQuery, PostDto>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetIsFeaturedPostQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<PostDto> Handle(GetIsFeaturedPostQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var post = await _postRepository.GetIsFeaturedPost();
            check(post);

            var postDto = _mapper.Map<PostDto>(post);
            return postDto;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }

    private void check(Post post)
    {
        if (post is null)
            throw new ArgumentNullException();
    }
}