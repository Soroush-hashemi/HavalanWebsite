using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetBySlug;
public class GetBySlugHandler : IRequestHandler<GetBySlug, CategoryDto>
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;
    public GetBySlugHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetBySlug request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _categoryRepository.GetBySlug(request.Slug);
            Check(category);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }

    }

    private void Check(Category category)
    {
        if (category is null)
        {
            throw new ArgumentException("دسته بندی مورد نظر پیدا نشد");
        }
    }
}
