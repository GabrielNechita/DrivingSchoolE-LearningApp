using System.IdentityModel.Tokens.Jwt;

namespace DriversPlatform.BLL.Services
{
    public interface IUserService
    {
        JwtSecurityToken CreateToken(string username, string role);
    }
}