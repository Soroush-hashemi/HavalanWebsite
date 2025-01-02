using Havalan.Application.Common;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Posts;
using MediatR;

namespace Havalan.Application.Posts.Commands.Delete;
public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, OperationResult>
{
    private readonly IPostRepository _postrepository;
    private readonly IFileService _fileservice;
    public DeletePostCommandHandler(IPostRepository postrepository, IFileService fileservice)
    {
        _postrepository = postrepository;
        _fileservice = fileservice;
    }

    public async Task<OperationResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var post = await _postrepository.GetTracking(request.PostId);
            Check(post);

            _postrepository.DeletePost(post);
            await _postrepository.Save();

            _fileservice.DeleteFile(Directories.PostImage , post.ImageName);
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    private void Check(Post Post)
    {
        if (Post is null)
            throw new ArgumentNullException("Post Is not Exist");
    }
}