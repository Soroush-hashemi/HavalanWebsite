using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.TrendingNews;
using MediatR;

namespace Havalan.Application.TrendingNews.Commands.Edit;
public class EditNewsCommandHandler : IRequestHandler<EditNewsCommand, OperationResult>
{
    private readonly ITrendingNewsRepository _trendingNewsRepository;
    public EditNewsCommandHandler(ITrendingNewsRepository trendingNewsRepository)
    {
        _trendingNewsRepository = trendingNewsRepository;
    }

    public async Task<OperationResult> Handle(EditNewsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var news = await _trendingNewsRepository.GetTracking(request.Id);
            check(news);
            news.Edit(request.Title);

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