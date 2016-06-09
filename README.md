# ASP.NET Core Vkontakte middleware
An ASP.NET Core middleware for authenticating users using Vkontakte

### Usage

```csharp
app.UseVkontakteAuthentication(new VkontakteOptions
{
    ClientId = Configuration["vkontakte:appid"],
    ClientSecret = Configuration["vkontakte:appsecret"],
    SaveTokens = true
});
```
