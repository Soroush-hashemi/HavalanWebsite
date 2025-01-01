using Havalan.Domain.Categories;

namespace Havalan.Application.Common.Interfaces;
public interface ICategoryRepository : IBaseRepository<Category>
{
    bool DeleteCategory(long categoryId);
    Task<Category> GetBySlug(string slug);
    List<Category> GetList();
}