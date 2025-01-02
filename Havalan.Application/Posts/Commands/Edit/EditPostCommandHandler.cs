using Havalan.Application.Common;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Posts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Havalan.Application.Posts.Commands.Edit;
public class EditPostCommandHandler : IRequestHandler<EditPostCommand, OperationResult>
{
    private readonly IPostDomainService _postDomainService;
    private readonly IPostRepository _postRepository;
    private readonly IFileService _fileService;

    public EditPostCommandHandler(IPostDomainService postDomainService,
        IPostRepository postRepository, IFileService fileService)
    {
        _postDomainService = postDomainService;
        _postRepository = postRepository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var post = await _postRepository.GetTracking(request.PostId);
            Check(post);

            var newImageUrl = await _fileService.
                SaveFileAndGenerateName(request.imageFile, Directories.PostImage);
            var oldImage = post.ImageName;

            post.Edit(request.categoryId, request.subCategoryId,
                request.title, request.slug, request.description,
                newImageUrl, request.isFeatured, request.isSidebar, _postDomainService);

            RemoveOldImage(request.imageFile, oldImage);

            await _postRepository.Save();
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(ex.Message);
        }
    }

    private void RemoveOldImage(IFormFile imageFile, string oldImageName)
    {
        if (imageFile != null)
        {
            _fileService.DeleteFile(Directories.PostImage, oldImageName);
        }
    }

    private void Check(Post post)
    {
        if (post == null)
            throw new ArgumentNullException("Post Not Exist");
    }
}