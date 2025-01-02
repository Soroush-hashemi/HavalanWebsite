using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.TrendingNews.Queries.DTO;
using Havalan.Application.TrendingNews.Queries.GetList;
using Havalan.Domain.TrendingNews;
using MediatR;

public class GetListOfNewsQueryHandler : IRequestHandler<GetListOfNewsQuery, List<TrendingNewDto>>
{
    private readonly ITrendingNewsRepository _trendingNewsRepository;
    private readonly IMapper _mapper;
    public GetListOfNewsQueryHandler(ITrendingNewsRepository trendingNewsRepository
        , IMapper mapper)
    {
        _trendingNewsRepository = trendingNewsRepository;
        _mapper = mapper;
    }

    public async Task<List<TrendingNewDto>> Handle(GetListOfNewsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var news = await _trendingNewsRepository.GetList();
            check(news);
            var newsDTO = _mapper.Map<List<TrendingNewDto>>(news);

            return newsDTO;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }

    private void check(List<TrendingNew> trendingNew)
    {
        if (trendingNew is null)
            throw new ArgumentNullException(nameof(trendingNew));
    }
}