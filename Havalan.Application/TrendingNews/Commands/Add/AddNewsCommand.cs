using Havalan.Domain.Common;
using MediatR;

namespace Havalan.Application.TrendingNews.Commands.Add;
public record AddNewsCommand(string Title) : IRequest<OperationResult>;