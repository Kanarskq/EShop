using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace EShop.Api.Domain.Auth
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsTransformation(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Extend with custom claims.
            return await ExtendWithCustomClaims(principal);
        }

        private async Task<ClaimsPrincipal> ExtendWithCustomClaims(ClaimsPrincipal principal)
        {
            // Clone current identity
            var principleClone = principal.Clone();
            var newIdentity = (ClaimsIdentity)principleClone.Identity!;

            // todo: pp implement polly
            // todo: pp check some possible exceptions
            try
            {
                // Add claims to cloned identity
                var contactClaims = new List<Claim>
                {
                    new("access", "CanSeeInfo")
                };

                // Add roles to cloned identity fetched from contact service 
                var contactRoleClaims = contactClaims;

                newIdentity.AddClaims(contactClaims);

                return principleClone;
            }
            catch (Exception e)
            {
                return principleClone;
            }
        }
    }
}
