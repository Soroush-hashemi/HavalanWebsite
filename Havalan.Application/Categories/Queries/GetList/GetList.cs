using Havalan.Application.Categories.Queries.DTOs;
using MediatR;

namespace Havalan.Application.Categories.Queries.GetList;
public class GetList : IRequest<List<CategoryDto>>;