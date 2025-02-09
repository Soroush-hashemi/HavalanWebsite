using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.TrendingNews.Queries.DTO;
using MediatR;

namespace Havalan.Application.TrendingNews.Queries.GetById;
public class GetByIdNewsQueryHandler : IRequestHandler<GetByIdNewsQuery, TrendingNewDto>
{
    private readonly ITrendingNewsRepository _trendingNewsRepository;
    private readonly IMapper _mapper;
    public GetByIdNewsQueryHandler(ITrendingNewsRepository trendingNewsRepository
        , IMapper mapper)
    {
        _trendingNewsRepository = trendingNewsRepository;
        _mapper = mapper;
    }

    public async Task<TrendingNewDto> Handle(GetByIdNewsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var news = await _trendingNewsRepository.GetTracking(request.Id);
            var newsDTO = _mapper.Map<TrendingNewDto>(news);

            return newsDTO;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }
}