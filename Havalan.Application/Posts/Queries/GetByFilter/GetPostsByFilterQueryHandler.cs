using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetByFilter;
public class GetPostsByFilterQueryHandler : IRequestHandler<GetPostsByFilterQuery, PostFilterDto>
{
    private readonly IPostRepository _postRepository;
    public GetPostsByFilterQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostFilterDto> Handle(GetPostsByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = _postRepository.GetAllPost();

        if (!string.IsNullOrWhiteSpace(request.FilterParams.Title))
            result = result.Where(r => r.Title.Contains(request.FilterParams.Title));

        if (!string.IsNullOrWhiteSpace(request.FilterParams.Slug))
            result = result.Where(r => r.Title.Contains(request.FilterParams.Slug));

        var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
        var model = new PostFilterDto()
        {
            FilterParams = request.FilterParams,
            Posts = result.Skip(skip).Take(request.FilterParams.Take)
                .Select(post => PostMapper.Map(post)).ToList(),
        };

        model.GeneratePaging(result, request.FilterParams.Take, request.FilterParams.PageId);

        return model;
    }
}