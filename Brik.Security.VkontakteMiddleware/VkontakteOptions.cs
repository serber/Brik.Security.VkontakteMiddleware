using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace Brik.Security.VkontakteMiddleware
{
    /// <summary>
    /// Configuration options
    /// </summary>
    public class VkontakteOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="VkontakteOptions"/>.
        /// </summary>
        public VkontakteOptions()
        {
            CallbackPath = new PathString(VkontakteDefault.CallbackPath);
            AuthorizationEndpoint = VkontakteDefault.AuthorizationEndpoint;
            TokenEndpoint = VkontakteDefault.TokenEndpoint;
            UserInformationEndpoint = VkontakteDefault.UserInformationEndpoint;
            ApiVersion = VkontakteDefault.DefaultApiVersion;
        }

        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets the list of fields to retrieve from the user information endpoint.
        /// See https://vk.com/dev/fields for more information.
        /// </summary>
        public ICollection<string> Fields { get; } = new HashSet<string> {
            "uid",
            "first_name",
            "last_name",
            "photo_rec",
            "photo",
            "hash",
            "screen_name",
            "domain"
        };
    }
}