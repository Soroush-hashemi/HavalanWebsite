using Havalan.Domain.TrendingNews;

namespace Havalan.Application.Common.Interfaces;
public interface ITrendingNewsRepository : IBaseRepository<TrendingNew>
{
    void DeleteTrendingNews(TrendingNew news);

    Task<List<TrendingNew>> GetList(); 
}