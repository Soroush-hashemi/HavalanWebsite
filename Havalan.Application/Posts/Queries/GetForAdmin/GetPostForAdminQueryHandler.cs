using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts.Queries.DTOs;
using Havalan.Domain.Posts;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetForAdmin;
public class GetPostForAdminQueryHandler : IRequestHandler<GetPostForAdminQuery, List<PostDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostForAdminQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetPostForAdminQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var Posts = await _postRepository.GetAllPostAsList();
            Check(Posts);

            var postsDto = _mapper.Map<List<PostDto>>(Posts);
            return postsDto;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }

    private void Check(List<Post> posts)
    {
        if (posts is null)
            throw new ArgumentNullException();
    }
}