using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.TrendingNews.Queries.DTO;
using Havalan.Web.Areas.Admin.Models.Category;
using Havalan.Web.Areas.Admin.Models.TrendingNews;

namespace Havalan.Web.Areas.Admin.Models.Mapping;
public class MvcMappingProfile : Profile
{
    public MvcMappingProfile()
    {
        CreateMap<CategoryDto, EditCategoryViewModel>();
        CreateMap<SubCategoryDto, EditCategoryViewModel>();
        CreateMap<TrendingNewDto, TrendingNewsViewModel>();
    }
}