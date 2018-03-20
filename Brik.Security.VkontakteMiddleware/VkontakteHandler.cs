using System.Net.Http;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace Brik.Security.VkontakteMiddleware
{
    public class VkontakteHandler : OAuthHandler<VkontakteOptions>
    {
        public VkontakteHandler(IOptionsMonitor<VkontakteOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
             : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var address = QueryHelpers.AddQueryString(Options.UserInformationEndpoint, "access_token", tokens.AccessToken);
            address = QueryHelpers.AddQueryString(address, "v", Options.ApiVersion);

            if (Options.Fields.Count != 0)
            {
                address = QueryHelpers.AddQueryString(address, "fields", string.Join(",", Options.Fields));
            }

            var response = await Backchannel.GetAsync(address, Context.RequestAborted);
            if (!response.IsSuccessStatusCode)
            {
                Logger.LogError("An error occurred while retrieving the user profile: the remote server " +
                                "returned a {Status} response with the following payload: {Headers} {Body}.",
                                /* Status: */ response.StatusCode,
                                /* Headers: */ response.Headers.ToString(),
                                /* Body: */ await response.Content.ReadAsStringAsync());

                throw new HttpRequestException("An error occurred while retrieving the user profile.");
            }

            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

            var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, Context, Scheme, Options, Backchannel, tokens, payload);
            var user = (JObject)payload["response"][0];

            identity.AddOptionalClaim(ClaimTypes.NameIdentifier, VkontakteHelper.GetId(user), Options.ClaimsIssuer)
                    .AddOptionalClaim(ClaimTypes.Name, VkontakteHelper.GetName(user), Options.ClaimsIssuer)
                    .AddOptionalClaim(ClaimTypes.GivenName, VkontakteHelper.GetFirstName(user), Options.ClaimsIssuer)
                    .AddOptionalClaim(ClaimTypes.Surname, VkontakteHelper.GetLastName(user), Options.ClaimsIssuer)
                    .AddOptionalClaim(ClaimTypes.Hash, VkontakteHelper.GetHash(user), Options.ClaimsIssuer)
                    .AddOptionalClaim("urn:vkontakte:photo:link", VkontakteHelper.GetPhoto(user), Options.ClaimsIssuer)
                    .AddOptionalClaim("urn:vkontakte:photo_thumb:link", VkontakteHelper.GetPhotoThumbnail(user), Options.ClaimsIssuer);
            
            context.RunClaimActions();

            await Events.CreatingTicket(context);

            return new AuthenticationTicket(context.Principal, context.Properties, Scheme.Name);
        }
    }
}