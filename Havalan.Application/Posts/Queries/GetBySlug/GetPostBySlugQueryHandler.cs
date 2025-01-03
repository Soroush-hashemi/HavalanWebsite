using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts.Queries.DTOs;
using Havalan.Domain.Posts;
using MediatR;
using System.Numerics;

namespace Havalan.Application.Posts.Queries.GetBySlug;
public class GetPostBySlugQueryHandler : IRequestHandler<GetPostBySlugQuery, PostDto>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetPostBySlugQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<PostDto> Handle(GetPostBySlugQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var post = await _postRepository.GetPostBySlug(request.Slug);
            Check(post);

            var postDto = _mapper.Map<PostDto>(post);
            return postDto;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }

    private void Check(Post post)
    {
        if (post is null)
            throw new ArgumentNullException();
    }
}