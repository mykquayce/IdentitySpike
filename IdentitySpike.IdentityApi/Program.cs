var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddIdentityServer()
	.AddInMemoryApiScopes(IdentitySpike.IdentityApi.Config.ApiScopes)
	.AddInMemoryClients(IdentitySpike.IdentityApi.Config.Clients);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseIdentityServer();

app.Run();
