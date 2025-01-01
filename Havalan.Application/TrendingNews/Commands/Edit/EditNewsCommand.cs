using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.TrendingNews.Commands.Edit;
public record EditNewsCommand(long Id, string Title) : IRequest<OperationResult>;