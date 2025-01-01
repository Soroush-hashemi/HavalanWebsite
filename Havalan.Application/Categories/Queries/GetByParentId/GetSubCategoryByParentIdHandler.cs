using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Categories;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetByParentId;
public class GetSubCategoryByParentIdHandler : IRequestHandler<GetSubCategoryByParentId, SubCategoryDto>
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;
    public GetSubCategoryByParentIdHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<SubCategoryDto> Handle(GetSubCategoryByParentId request, CancellationToken cancellationToken)
    {
        try
        {
            var subcategory = await _categoryRepository.GetTracking(request.ParentId);
            Check(subcategory);
            var subcategoryDto = _mapper.Map<SubCategoryDto>(subcategory);
            return subcategoryDto;
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