using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Domain.Categories;

namespace Havalan.Application.Common;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category,  CategoryDto>();

    }
}