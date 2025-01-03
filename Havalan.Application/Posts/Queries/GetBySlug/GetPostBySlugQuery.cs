using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetBySlug;
public record GetPostBySlugQuery(string Slug) : IRequest<PostDto>;