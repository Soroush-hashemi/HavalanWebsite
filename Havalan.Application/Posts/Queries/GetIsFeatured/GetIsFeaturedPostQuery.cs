using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetIsFeatured;
public record GetIsFeaturedPostQuery : IRequest<PostDto>;