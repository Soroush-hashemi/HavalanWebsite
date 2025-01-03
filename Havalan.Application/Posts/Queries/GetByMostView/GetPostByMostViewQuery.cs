using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetByMostView;
public record GetPostByMostViewQuery : IRequest<List<PostDto>>;