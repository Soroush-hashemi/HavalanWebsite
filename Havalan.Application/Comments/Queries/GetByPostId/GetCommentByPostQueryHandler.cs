using AutoMapper;
using Havalan.Application.Comments.Queries.DTO;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Comments;
using MediatR;

namespace Havalan.Application.Comments.Queries.GetByPostId;
public class GetCommentByPostQueryHandler : IRequestHandler<GetCommentByPostIdQuery, CommentDto>
{
    private readonly ICommentsRepository _commentsRepository;
    private readonly IMapper _mapper;
    public GetCommentByPostQueryHandler(ICommentsRepository commentsRepository, IMapper mapper)
    {
        _commentsRepository = commentsRepository;
        _mapper = mapper;
    }

    public async Task<CommentDto> Handle(GetCommentByPostIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var comment = await _commentsRepository.GetByPostId(request.PostId);

            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }
}