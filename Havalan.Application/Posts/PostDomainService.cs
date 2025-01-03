using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Posts;

namespace Havalan.Application.Posts;
public class PostDomainService : IPostDomainService
{
    private readonly IPostRepository _postRepository;
    public PostDomainService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public OperationResult IsSlugExist(string slug)
    {
        var Exists = _postRepository.Exists(s => s.Slug == slug);
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("Slug تکراری است");
    }
}