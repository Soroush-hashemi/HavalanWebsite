using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Categories.Commands.Delete;
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, OperationResult>
{
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = _categoryRepository.DeleteCategory(request.CategoryId);

            await _categoryRepository.Save();
            if (result != true)
                return OperationResult.Error("دسته بندی حذف نشد");

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}