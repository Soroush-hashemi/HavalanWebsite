using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.TrendingNews;
using MediatR;

namespace Havalan.Application.TrendingNews.Commands.Delete;
public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, OperationResult>
{
    private readonly ITrendingNewsRepository _trendingNewsRepository;
    public DeleteNewsCommandHandler(ITrendingNewsRepository trendingNewsRepository)
    {
        _trendingNewsRepository = trendingNewsRepository;
    }

    public async Task<OperationResult> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var news = await _trendingNewsRepository.GetTracking(request.Id);
            check(news);
            _trendingNewsRepository.DeleteTrendingNews(news);
            await _trendingNewsRepository.Save();

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    private void check(TrendingNew news)
    {
        if (news is null)
            throw new ArgumentNullException(nameof(news));
    }
}