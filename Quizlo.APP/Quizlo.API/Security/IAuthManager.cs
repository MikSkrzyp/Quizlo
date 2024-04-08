using Microsoft.AspNetCore.Identity;
using Quizlo.API.DTOs;

namespace Quizlo.API.Security
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(UserDto userDto);
        Task<TokenDto> Login(LoginDto loginDto);

        Task<string> CreateRefreshToken();

        Task<TokenDto> VerifyRefreshToken(TokenDto tokenDto);
    }
}
