using Havalan.Domain.Base;
using Havalan.Domain.Common;

namespace Havalan.Domain.Posts;
public class Post : BaseEntity
{
    private Post() { }

    public long CategoryId { get; private set; }
    public long SubCategoryId { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
    public string ImageName { get; private set; }
    public int Visit { get; private set; }
    public bool IsFeatured { get; private set; }
    public bool IsSidebar { get; private set; }

    public Post(long categoryId, long subCategoryId,
        string title, string slug, string description,
        string imageName, bool isFeatured, bool isSidebar,
        IPostDomainService domainService)
    {
        CheckInputs(title, slug, description, domainService);
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Title = title;
        Slug = slug.ToSlug();
        Description = description;
        ImageName = imageName;
        Visit = 0;
        IsFeatured = isFeatured;
        IsSidebar = isSidebar;
    }

    public void Edit(long categoryId, long subCategoryId,
        string title, string slug, string description,
        string imageName, bool isFeatured, bool isSidebar,
    IPostDomainService domainService)
    {
        CheckInputs(title, slug, description, domainService);
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Title = title;
        Slug = slug.ToSlug();
        Description = description;
        ImageName = imageName;
        IsFeatured = isFeatured;
        IsSidebar = isSidebar;
    }

    public void Visited()
    {
        Visit += 1;
    }

    private void CheckInputs(string title, string slug, string description, IPostDomainService domainService)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        NullOrEmptyException.CheckString(description, nameof(description));
        NullOrEmptyException.CheckString(slug, nameof(slug));

        if (Slug != slug)
        {
            var result = domainService.IsSlugExist(slug);
            if (result.Status != OperationResultStatus.Success)
                throw new NullOrEmptyException(result.Message);
        }

    }
}