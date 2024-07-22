using ProductContext.Domain.Entities;
using System.Security.Claims;

namespace ProductContext.Api.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
            };

            result.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Title)));

            return result;
        }
    }
}
