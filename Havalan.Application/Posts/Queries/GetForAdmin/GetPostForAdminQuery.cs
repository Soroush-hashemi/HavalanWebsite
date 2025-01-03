using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetForAdmin;
public record GetPostForAdminQuery : IRequest<List<PostDto>>;