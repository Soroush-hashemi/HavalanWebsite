using Havalan.Application.Common.Interfaces;
using Havalan.Infrastructure.Categories.Persistence;
using Havalan.Infrastructure.Comments.Persistence;
using Havalan.Infrastructure.Common.Persistence;
using Havalan.Infrastructure.Posts.Persistence;
using Havalan.Infrastructure.TrendingNews.Persistence;
using Havalan.Infrastructure.Users.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Havalan.Infrastructure;
public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services , string connectionString)
    {
        return services.AddPersistence(connectionString);
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services ,string connectionString)
    {
        services.AddTransient<ICategoryRepository , CategoryRepository>();
        services.AddTransient<IPostRepository , PostRepository>();
        services.AddTransient<IUserRepository , UserRepository>();
        services.AddTransient<ICategoryRepository , CategoryRepository>();
        services.AddTransient<ICommentsRepository , CommentRepository>();
        services.AddTransient<ITrendingNewsRepository , TrendingNewsRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<HavalanDbContext>());

        services.AddDbContext<HavalanDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });

        return services;
    }
}