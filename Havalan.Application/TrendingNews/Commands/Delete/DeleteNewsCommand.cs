using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.TrendingNews.Commands.Delete;
public record DeleteNewsCommand(long Id) : IRequest<OperationResult>;