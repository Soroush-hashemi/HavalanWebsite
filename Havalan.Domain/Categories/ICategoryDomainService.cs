using Havalan.Domain.Common;

namespace Havalan.Domain.Categories;
public interface ICategoryDomainService
{
    public OperationResult IsSlugExist(string slug);
}