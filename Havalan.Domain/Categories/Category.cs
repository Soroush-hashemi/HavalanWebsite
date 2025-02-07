using Havalan.Domain.Base;
using Havalan.Domain.Common;

namespace Havalan.Domain.Categories;
public class Category : BaseEntity
{
    private Category() 
    {
        SubCategory = new List<Category>();
    }

    public string Title { get; private set; }
    public string Slug { get; private set; }
    public long? ParentId { get; private set; }
    public List<Category> SubCategory { get; private set; }

    public Category(string title, string slug, ICategoryDomainService domainService)
    {
        slug = slug.ToSlug();
        CheckInputs(title, slug, domainService);
        Title = title;
        Slug = slug;
        SubCategory = new List<Category>();
    }

    public void Edit(string title, string slug, ICategoryDomainService domainService)
    {
        slug = slug.ToSlug();
        CheckInputs(title, slug, domainService);
        Title = title;
        Slug = slug;
    }

    public void AddChild(string title, string slug, ICategoryDomainService domainService)
    {
        SubCategory.Add(new Category(title, slug, domainService)
        {
            ParentId = Id
        });
    }

    private void CheckInputs(string title, string slug, ICategoryDomainService domainService)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        NullOrEmptyException.CheckString(slug, nameof(slug));

        if (Slug != slug)
        {
            var result = domainService.IsSlugExist(slug);
            if (result.Status != OperationResultStatus.Success)
                throw new NullOrEmptyException(result.Message);
        }
    }
}