using Havalan.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Havalan.Application.Posts.Commands.Create;
public record CreatePostCommand(long categoryId, long subCategoryId,
        string title, string slug, string description,
        IFormFile imageFile, bool isFeatured, bool isSidebar) : IRequest<OperationResult>;