using Authentication.Domain.Entities;

namespace Authentication.Application.Interfaces
{
    public interface IJwtHelper
    {
        string GenerateToken(User user);
    }
}
