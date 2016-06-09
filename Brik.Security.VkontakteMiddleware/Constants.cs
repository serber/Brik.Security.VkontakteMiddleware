﻿namespace Brik.Security.VkontakteMiddleware
{
    public static class Constants
    {
        public const string AuthenticationScheme = "Vkontakte";
        
        public const string TokenEndpoint = "https://oauth.vk.com/access_token";

        public const string GraphApiEndpoint = "https://api.vk.com/method/users.get.json";

        public const string AuthorizeEndpoint = "https://oauth.vk.com/authorize";
    }
}