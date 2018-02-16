using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Brik.Security.VkontakteMiddleware
{
    /// <summary>
    /// Extension methods to add Vkontakte authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class VkontakteExtensions
    {
        public static AuthenticationBuilder AddVkontakte(this AuthenticationBuilder builder)
            => builder.AddVkontakte(VkontakteDefault.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddVkontakte(this AuthenticationBuilder builder, Action<VkontakteOptions> configureOptions)
            => builder.AddVkontakte(VkontakteDefault.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddVkontakte(this AuthenticationBuilder builder, string authenticationScheme, Action<VkontakteOptions> configureOptions)
            => builder.AddVkontakte(authenticationScheme, VkontakteDefault.DisplayName, configureOptions);

        public static AuthenticationBuilder AddVkontakte(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<VkontakteOptions> configureOptions)
            => builder.AddOAuth<VkontakteOptions, VkontakteHandler>(authenticationScheme, displayName, configureOptions);
    }
}