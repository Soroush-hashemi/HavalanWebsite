using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetByFilter;
public class GetPostsByFilterQueryHandler : IRequestHandler<GetPostsByFilterQuery, PostFilterDto>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetPostsByFilterQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<PostFilterDto> Handle(GetPostsByFilterQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = _postRepository.GetAllPostAsEnumerable();

            if (!string.IsNullOrWhiteSpace(request.FilterParams.Title))
                result = result.Where(r => r.Title.Contains(request.FilterParams.Title));

            if (!string.IsNullOrWhiteSpace(request.FilterParams.Slug))
                result = result.Where(r => r.Title.Contains(request.FilterParams.Slug));

            var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
            var model = new PostFilterDto()
            {
                FilterParams = request.FilterParams,
                Posts = result.Skip(skip).Take(request.FilterParams.Take)
                    .Select(post => _mapper.Map<PostDto>(post)).ToList(),
            };

            model.GeneratePaging(result, request.FilterParams.Take, request.FilterParams.PageId);

            return model;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }
}