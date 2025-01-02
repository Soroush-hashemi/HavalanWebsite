using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Posts;
using MediatR;

namespace Havalan.Application.Posts.Commands.IncreaseView;
public class IncreaseViewCommandHandler : IRequestHandler<IncreaseViewCommand, OperationResult>
{
    private readonly IPostRepository _postRepository;
    public IncreaseViewCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<OperationResult> Handle(IncreaseViewCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var post = await _postRepository.GetTracking(request.postId);
            Check(post);

            post.Visited();

            await _postRepository.Save();
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    private void Check(Post post)
    {
        if (post == null)
            throw new ArgumentNullException("Post Not Exist");
    }
}