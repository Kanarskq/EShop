using Auth0.AspNetCore.Authentication;
using EShop.Web.Clients;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IClient, Client>((HttpClient httpClient, IServiceProvider provider) =>
{
    return new Client("https://localhost:7086/", httpClient);
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddAuth0WebAppAuthentication(
        options =>
        {
            options.Domain = builder.Configuration["Auth0:Domain"];
            options.ClientId = builder.Configuration["Auth0:ClientId"];
            options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
        })
    .WithAccessToken(options =>
    {
        options.Audience = builder.Configuration["Auth0:Audience"];
        options.Scope = "openid profile email offline_access audience permissions issuer read:info";
    }); ;

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAuthenticatedUser", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAuthenticatedUser", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "products",
    pattern: "/products/{action}/{id?}",
    defaults: new { controller = "Products" });

app.MapControllerRoute(
    name: "Users",
    pattern: "/users/{action}/{id?}",
    defaults: new { controller = "Users" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action}/{id?}",
    defaults: new { controller = "Home" });

app.Run();
