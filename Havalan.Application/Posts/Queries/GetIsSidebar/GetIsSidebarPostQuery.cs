using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetIsSidebar;
public record GetIsSidebarPostQuery : IRequest<List<PostDto>>;