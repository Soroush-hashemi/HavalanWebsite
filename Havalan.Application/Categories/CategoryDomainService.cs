using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using Havalan.Domain.Common;

namespace Havalan.Application.Categories;
public class CategoryDomainService : ICategoryDomainService
{
    private readonly ICategoryRepository _repository;
    public CategoryDomainService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public OperationResult IsSlugExist(string slug)
    {
        var Exists = _repository.Exists(s => s.Slug == slug);
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("Slug تکراری است");
    }
}