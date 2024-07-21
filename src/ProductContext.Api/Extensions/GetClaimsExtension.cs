using System.Security.Claims;

namespace ProductContext.Api.Extensions
{
    public static class GetClaimsExtension
    {
        public static string GetEmailClaim(this HttpContext httpContext)
            => httpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
    }
}
