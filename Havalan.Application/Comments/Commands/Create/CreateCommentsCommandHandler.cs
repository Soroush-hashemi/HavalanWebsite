using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Comments;
using MediatR;

namespace Havalan.Application.Comments.Commands.Create;
public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommand, OperationResult>
{
    private readonly ICommentsRepository _commentsRepository;
    public CreateCommentsCommandHandler(ICommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    public async Task<OperationResult> Handle(CreateCommentsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var comment = new Comment(request.PostId, request.UserName, request.Text);

            _commentsRepository.Add(comment);
            await _commentsRepository.Save();

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}