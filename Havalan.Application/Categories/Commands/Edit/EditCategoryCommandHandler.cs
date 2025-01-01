
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Categories.Commands.Edit;
public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, OperationResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;
    public EditCategoryCommandHandler(ICategoryRepository categoryRepository,
        ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _categoryRepository.GetTracking(request.CategoryId);
            Check(category);
            category.Edit(request.Title , request.Slug, _categoryDomainService);

            await _categoryRepository.Save();

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    public void Check(Category category)
    {
        if (category is null)
            throw new ArgumentNullException(nameof(category));
    }
}