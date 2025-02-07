using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Web.Areas.Admin.Models.Category;

namespace Havalan.Web.Areas.Admin.Models.Mapping;
public class MvcMappingProfile : Profile
{
    public MvcMappingProfile()
    {
        CreateMap<CategoryDto, EditCategoryViewModel>();
        CreateMap<SubCategoryDto, EditCategoryViewModel>();
    }
}