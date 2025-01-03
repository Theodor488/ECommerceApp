using ECommerceAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EcommerceAPI.Repositories
{
    public interface ITokenRepository
    {
        string GenerateToken(IdentityUser user, List<string> roles);
    }
}
