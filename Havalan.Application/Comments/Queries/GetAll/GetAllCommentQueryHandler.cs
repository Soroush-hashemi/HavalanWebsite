using AutoMapper;
using Havalan.Application.Comments.Queries.DTO;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Comments;
using MediatR;

namespace Havalan.Application.Comments.Queries.GetAll;
public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, List<CommentDto>>
{
    private readonly ICommentsRepository _commentsRepository;
    private readonly IMapper _mapper;
    public GetAllCommentQueryHandler(ICommentsRepository commentsRepository,
        IMapper mapper)
    {
        _commentsRepository = commentsRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var comments = _commentsRepository.GetAllComments();
            Check(comments);

            var CommentsDto = _mapper.Map<List<CommentDto>>(comments);
            foreach (var item in CommentsDto)
            {
                item.PostSlug = _commentsRepository.GetPostSlug(item.PostId);
            }

            return CommentsDto;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }


    private void Check(List<Comment> comment)
    {
        if (comment is null) 
            throw new ArgumentNullException(nameof(comment));
    }
}