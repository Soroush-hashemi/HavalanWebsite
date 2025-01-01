using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.Common.Interfaces;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetList;
public class GetListHandler : IRequestHandler<GetList, List<CategoryDto>>
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;
    public GetListHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetList request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = _categoryRepository.GetList();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDto;
        }
        catch (Exception ex)
        { 
            throw new ArgumentNullException(ex.Message);
        }
    }
}