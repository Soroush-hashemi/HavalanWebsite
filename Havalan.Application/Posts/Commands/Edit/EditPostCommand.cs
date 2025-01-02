using Havalan.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Havalan.Application.Posts.Commands.Edit;
public record EditPostCommand(long PostId,long categoryId, long subCategoryId,
        string title, string slug, string description,
        IFormFile imageFile, bool isFeatured, bool isSidebar) : IRequest<OperationResult>;