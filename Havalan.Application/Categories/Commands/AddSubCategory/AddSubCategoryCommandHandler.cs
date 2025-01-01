using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Categories.Commands.AddSubCategory;
public class AddSubCategoryCommandHandler : IRequestHandler<AddSubCategoryCommand, OperationResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public AddSubCategoryCommandHandler(ICategoryRepository categoryRepository
        , ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(AddSubCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _categoryRepository.GetTracking(request.parentId);
            Check(category);
            category.AddChild(request.title , request.slug , _categoryDomainService);

            await _categoryRepository.Save();
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    private void Check(Category category)
    {
        if (category is null) 
            throw new ArgumentNullException(nameof(category));
    }
}