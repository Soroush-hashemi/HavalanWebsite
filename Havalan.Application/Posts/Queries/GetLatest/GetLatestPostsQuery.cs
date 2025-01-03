using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetLatest;
public record GetLatestPostsQuery : IRequest<List<PostDto>>;
