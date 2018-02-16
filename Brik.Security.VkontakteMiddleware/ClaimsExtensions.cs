using System;
using System.Security.Claims;

namespace Brik.Security.VkontakteMiddleware
{
    internal static class ClaimsExtensions
    {
        internal static ClaimsIdentity AddOptionalClaim(this ClaimsIdentity identity, string type, string value, string issuer)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(value))
            {
                return identity;
            }

            identity.AddClaim(new Claim(type, value, ClaimValueTypes.String, issuer ?? ClaimsIdentity.DefaultIssuer));
            return identity;
        }
    }
}