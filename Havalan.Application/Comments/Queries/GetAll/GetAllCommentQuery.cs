using Havalan.Application.Comments.Queries.DTO;
using MediatR;

namespace Havalan.Application.Comments.Queries.GetAll;
public record GetAllCommentQuery : IRequest<List<CommentDto>>;