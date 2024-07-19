using IdentityServer4;
using IdentityServer4.Quickstart.UI;
using TokenService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(Config.GetIdentityResources())
    .AddInMemoryClients(Config.GetClients())
    .AddTestUsers(TestUsers.Users);

builder.Services.AddAuthentication().AddGoogle(options =>
{
    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
    options.ClientId = "399242189379-o1vq2mv9i21rg2te7lelinig0vvd61r8.apps.googleusercontent.com";
    options.ClientSecret = "m2ta2MrYnOVITPSzpAHnGoTj";
});
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();
//app.UseMvcWithDefaultRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
