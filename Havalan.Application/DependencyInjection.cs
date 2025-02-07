using AutoMapper;
using Havalan.Application.Categories;
using Havalan.Application.Categories.Commands.CreateCategory;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.Common;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Posts;
using Havalan.Application.Users;
using Havalan.Domain.Categories;
using Havalan.Domain.Posts;
using Havalan.Domain.Users;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Havalan.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<ICategoryDomainService , CategoryDomainService>();
        services.AddTransient<IPostDomainService , PostDomainService>();
        services.AddTransient<IUserDomainService , UserDomainService>();

        services.AddMediatR(typeof(CreateCategoryCommand).Assembly);
        services.AddMediatR(typeof(CreateCategoryCommandHandler).Assembly);

        return services;
    }
}