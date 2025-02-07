using Havalan.Application.Users.Queries.DTO;
using MediatR;

namespace Havalan.Application.Users.Queries.GetAllForAdmin;
public class GetAllUserForAdminQuery : IRequest<List<UserDto>>;