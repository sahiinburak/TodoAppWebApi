using TodoAppWebApi.Models;

namespace TodoAppWebApi.Services
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}
