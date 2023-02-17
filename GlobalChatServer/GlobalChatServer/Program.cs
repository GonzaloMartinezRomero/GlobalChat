using Azure.Identity;
using GlobalChatServer.AppConfiguration;
using GlobalChatServer.GlobalChatHubs;
using GlobalChatServer.Model;

const string POLICY_CORS = "ChatAppClientCORS";
const string KEYVAULT_ENDPOINT = "KEYVAULT_ENDPOINT";

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsProduction())
{
    string endpoint = Environment.GetEnvironmentVariable(KEYVAULT_ENDPOINT) ?? throw new ArgumentNullException(KEYVAULT_ENDPOINT);

    Uri keyVaultUri = new Uri(endpoint);
    builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();

GlobalChatNetworkConfiguration globalChatNetworkConfiguration = builder.Configuration.LoadGlobalChatConfiguration();

builder.Services.AddCors(setup =>
{
    setup.AddPolicy(POLICY_CORS,
        policy =>
        {            
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.SetIsOriginAllowed(origin => true);
            policy.AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseCors(POLICY_CORS);

app.UseAuthorization();

app.MapHub<ChatHub>(globalChatNetworkConfiguration.HubEndpoint);

app.MapControllers();

app.Run();
