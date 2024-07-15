using IdentityServerHost.Quickstart.UI;
using TokenService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(Config.GetIdentityResources())
    .AddInMemoryClients(Config.GetClients())
    .AddTestUsers(TestUsers.Users);
builder.Services.AddMvc();
WebApplication app = builder.Build();
app.UseIdentityServer();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();
