using Havalan.Application.Common.Interfaces;
using Havalan.Domain.TrendingNews;
using Havalan.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Havalan.Infrastructure.TrendingNews.Persistence;
public class TrendingNewsRepository : BaseRepository<TrendingNew>, ITrendingNewsRepository
{
    public TrendingNewsRepository(HavalanDbContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
    }

    public void DeleteTrendingNews(TrendingNew news)
    {
        _context.TrendingNews.Remove(news);
    }

    public Task<List<TrendingNew>> GetList()
    {
        return _context.TrendingNews.OrderByDescending(d => d.CreationDate).ToListAsync();
    }
}