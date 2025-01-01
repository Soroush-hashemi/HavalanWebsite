using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using Havalan.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Havalan.Infrastructure.Categories.Persistence;
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(HavalanDbContext context, IUnitOfWork unitOfWork) : base(context , unitOfWork)
    {
    }

    public bool DeleteCategory(long categoryId)
    {
        var category = _context.Categories.Include(category => category.SubCategory)
            .FirstOrDefault(c => c.Id.Equals(categoryId));

        if (category == null)
            return false;

        var hasPostInCategory = _context.Posts
            .Any(c => c.CategoryId == categoryId || c.SubCategoryId == categoryId);

        if (hasPostInCategory)
            return false;

        if (category.SubCategory.Count() > 0)
        {
            _context.RemoveRange(category.SubCategory);
        }
        _context.RemoveRange(category);

        return true;
    }

    public async Task<Category> GetBySlug(string slug)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Slug == slug);
        if (category == null) throw new Exception();
        return category;
    }

    public List<Category> GetList()
    {
        return _context.Categories.Include(c => c.SubCategory).OrderByDescending(c => c.Id).ToList();
    }
}