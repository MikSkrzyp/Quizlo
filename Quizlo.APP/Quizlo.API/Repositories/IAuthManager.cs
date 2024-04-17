using Microsoft.AspNetCore.Identity;
using Quizlo.API.Model.DTOs;

namespace Quizlo.API.Repositories
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(UserDto userDto);
        Task<TokenDto> Login(LoginDto loginDto);

        Task<string> CreateRefreshToken();

        Task<TokenDto> VerifyRefreshToken(TokenDto tokenDto);
    }
}
