using AutoMapper;
using Havalan.Application.Common.Interfaces;
using Havalan.Application.Users.Queries.DTO;
using Havalan.Domain.Users;
using MediatR;

namespace Havalan.Application.Users.Queries.GetAllForAdmin;
public class GetAllForAdminQueryHandler : IRequestHandler<GetAllUserForAdminQuery, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetAllForAdminQueryHandler(IUserRepository userRepository
        , IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetAllUserForAdminQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await _userRepository.GetList();
            Check(users);

            var usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(nameof(ex));
        }
    }

    private void Check(List<User> users)
    {
        if (users == null)
            throw new ArgumentNullException(nameof(users));
    }
}