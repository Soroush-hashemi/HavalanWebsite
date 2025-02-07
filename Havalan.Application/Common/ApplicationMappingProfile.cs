using AutoMapper;
using Havalan.Application.Categories.Queries.DTOs;
using Havalan.Application.Posts.Queries.DTOs;
using Havalan.Application.TrendingNews.Queries.DTO;
using Havalan.Application.Users.Queries.DTO;
using Havalan.Domain.Base;
using Havalan.Domain.Categories;
using Havalan.Domain.Posts;
using Havalan.Domain.TrendingNews;
using Havalan.Domain.Users;

namespace Havalan.Application.Common;
public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<TrendingNew, TrendingNewDto>();
        CreateMap<User, UserDto>();
        CreateMap<Post, PostDto>();
        CreateMap<BaseEntity, BaseDto>();
    }
}