using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.TrendingNews;
using MediatR;

namespace Havalan.Application.TrendingNews.Commands.Add;
public class AddNewsCommandHandler : IRequestHandler<AddNewsCommand, OperationResult>
{
    private ITrendingNewsRepository _trendingNewsRepository;
    public AddNewsCommandHandler(ITrendingNewsRepository trendingNewsRepository)
    {
        _trendingNewsRepository = trendingNewsRepository;
    }

    public async Task<OperationResult> Handle(AddNewsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var TrendingNew = new TrendingNew(request.Title);
            _trendingNewsRepository.Add(TrendingNew);
            await _trendingNewsRepository.Save();

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error();
        }
    }
}