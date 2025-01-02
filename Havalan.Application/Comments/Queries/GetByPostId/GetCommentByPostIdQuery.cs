using Havalan.Application.Comments.Queries.DTO;
using MediatR;

namespace Havalan.Application.Comments.Queries.GetByPostId;
public record GetCommentByPostIdQuery(long PostId) : IRequest<CommentDto>;