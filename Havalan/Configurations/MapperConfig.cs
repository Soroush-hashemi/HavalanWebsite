using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.Common;
using Havalan.Web.Areas.Admin.Models.Category;
using Havalan.Web.Areas.Admin.Models.Mapping;

namespace Havalan.Web.Configurations;
public static class MapperConfig
{
    public static void ConfigureMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Havalan.Domain.Categories.Category, CategoryDto>();
            cfg.CreateMap<CategoryDto, EditCategoryViewModel>();
            cfg.AddProfile<MvcMappingProfile>();
            cfg.AddProfile<ApplicationMappingProfile>();
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}