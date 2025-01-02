using Havalan.Application.Common;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Posts;
using MediatR;

namespace Havalan.Application.Posts.Commands.Create;
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, OperationResult>
{
    private readonly IPostRepository _postRepository;
    private readonly IPostDomainService _postDomainService;
    private readonly IFileService _fileService;
    public CreatePostCommandHandler(IPostRepository postRepository,
        IPostDomainService postDomainService)
    {
        _postDomainService = postDomainService;
        _postRepository = postRepository;
    }

    public async Task<OperationResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ImageUrl = await _fileService.SaveFileAndGenerateName(request.imageFile, Directories.PostImage);

            var post = new Post(request.categoryId, request.subCategoryId,
                request.title, request.slug, request.description,
                ImageUrl, request.isFeatured, request.isFeatured, _postDomainService);

            _postRepository.Add(post);
            await _postRepository.Save();

            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}