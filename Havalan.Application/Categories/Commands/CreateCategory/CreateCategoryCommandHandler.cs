using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Categories.Commands.CreateCategory;
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, OperationResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository
        , ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = new Category(request.Title, request.Slug, _categoryDomainService);

            _categoryRepository.Add(category);
            
            await _categoryRepository.Save();

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}