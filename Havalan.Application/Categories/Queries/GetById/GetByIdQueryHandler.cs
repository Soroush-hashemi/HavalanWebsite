using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetById;
public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CategoryDto>
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;
    public GetByIdQueryHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _categoryRepository.GetTracking(request.CategoryId);
            Check(category);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
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