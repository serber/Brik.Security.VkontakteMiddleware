# ASP.NET Core Vkontakte middleware
An ASP.NET Core middleware for authenticating users using Vkontakte

### Installing
```
PM> Install-Package Brik.Security.VkontakteMiddleware -Pre
```

### Usage

```csharp
app.UseVkontakteAuthentication(new VkontakteOptions
{
    ClientId = Configuration["vkontakte:appid"],
    ClientSecret = Configuration["vkontakte:appsecret"],
    SaveTokens = true
});
```

### This is an obsolete version, please use middleware from
https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src/AspNet.Security.OAuth.Vkontakte
