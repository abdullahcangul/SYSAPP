using SYS.Domain.Entities.Identity;

namespace Application.Abstractions.Token;

public interface ITokenHandler
{
    SYS.Application.DTOs.Token CreateAccessToken(int second, AppUser appUser);
    string CreateRefreshToken();
}