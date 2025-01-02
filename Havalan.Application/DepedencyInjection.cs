using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.Common;
using Havalan.Domain.Categories;
using Microsoft.Extensions.DependencyInjection;

namespace Havalan.Application;
public class DepedencyInjection
{
    public static void ConfigureAutoMapper(IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category , CategoryDto>();
            cfg.AddProfile<MappingProfile>();
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}