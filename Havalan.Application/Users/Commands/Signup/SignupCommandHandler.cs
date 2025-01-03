using Havalan.Application.Common;
using Havalan.Application.Common.Interfaces;
using Havalan.Domain.Common;
using Havalan.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Havalan.Application.Users.Commands.Signup;
public class SignupCommandHandler : IRequestHandler<SignupCommand, OperationResult<ClaimsPrincipal>>
{
    private readonly IUserRepository _userRepository;
    public SignupCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult<ClaimsPrincipal>> Handle(SignupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetByUserName(request.userName);
            Check(user);
            PasswordChecker(request.password, user.Password);

            List<Claim> claims = new List<Claim>()
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName.ToString()),
            new Claim(ClaimTypes.Role, user.Roles.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);

            //var properties = new AuthenticationProperties()
            //{
            //    IsPersistent = true
            //};
            //await HttpContext.SignInAsync(claimPrincipal, properties);

            return OperationResult<ClaimsPrincipal>.Success(claimPrincipal);
        }
        catch (Exception ex)
        {
            return OperationResult<ClaimsPrincipal>.Error(ex.Message);
        }
    }

    private void Check(User user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user));
    }

    public void PasswordChecker(string entrypassword, string oldpassword)
    {
        var password = Hasher.Hash(entrypassword);
        if (password != oldpassword)
            throw new ArgumentNullException("the password is wrong !");
    }
}