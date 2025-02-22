using Havalan.Application.Posts.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Posts.Queries.GetById;
public record GetPostByIdQuery(long Id) : IRequest<PostDto>;