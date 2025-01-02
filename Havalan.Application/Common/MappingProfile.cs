using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.TrendingNews.Queries.DTO;
using Havalan.Domain.Base;
using Havalan.Domain.Categories;
using Havalan.Domain.TrendingNews;

namespace Havalan.Application.Common;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category,  CategoryDto>();
        CreateMap<TrendingNew, TrendingNewDto>();
        CreateMap<BaseEntity, BaseDto>();
    }
}