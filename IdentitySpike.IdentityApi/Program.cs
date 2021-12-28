var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddIdentityServer()
	.AddDeveloperSigningCredential()        //This is for dev only scenarios when you don’t have a certificate to use.
	.AddInMemoryApiScopes(IdentitySpike.IdentityApi.Config.ApiScopes)
	.AddInMemoryClients(IdentitySpike.IdentityApi.Config.Clients);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseIdentityServer();

app.Run();
