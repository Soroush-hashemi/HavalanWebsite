using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Comments;
using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.Comments.Commands.Delete;
public class DeleteCommentsCommandHandler : IRequestHandler<DeleteCommentsCommand, OperationResult>
{
    private readonly ICommentsRepository _commentsRepository;
    public DeleteCommentsCommandHandler(ICommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    public async Task<OperationResult> Handle(DeleteCommentsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var comment = await _commentsRepository.GetTracking(request.commentId);
            check(comment);

            _commentsRepository.DeleteComment(comment);
            await _commentsRepository.Save();

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    private void check(Comment comment)
    {
        if (comment is null)
            throw new ArgumentNullException();
    }
}