using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Brik.Security.VkontakteMiddleware
{
    /// <summary>
    /// Default values used by the Vkontakte authentication middleware.
    /// </summary>
    public static class VkontakteDefault
    {
        /// <summary>
        /// Default value for <see cref="Microsoft.AspNetCore.Authentication.AuthenticationScheme"/>.
        /// </summary>
        public const string AuthenticationScheme = "Vkontakte";

        /// <summary>
        /// Default value for <see cref="OAuthOptions"/>.
        /// </summary>
        public const string DisplayName = "Vkontakte";

        /// <summary>
        /// Default value for <see cref="RemoteAuthenticationOptions.CallbackPath"/>.
        /// </summary>
        public const string CallbackPath = "/signin-vkontakte";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.AuthorizationEndpoint"/>.
        /// </summary>
        public const string AuthorizationEndpoint = "https://oauth.vk.com/authorize";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.TokenEndpoint"/>.
        /// </summary>
        public const string TokenEndpoint = "https://oauth.vk.com/access_token";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.UserInformationEndpoint"/>.
        /// </summary>
        public const string UserInformationEndpoint = "https://api.vk.com/method/users.get.json";

        /// <summary>
        /// Default API version
        /// </summary>
        internal const string DefaultApiVersion = "5.73";
    }
}