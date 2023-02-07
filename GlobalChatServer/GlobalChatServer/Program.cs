using GlobalChatServer.GlobalChatHubs;

const string POLICY_CORS = "ChatAppClientCORS";
const string CLIENT_URL_CONFIG_KEY = "ClientUrl";
const string HUB_ENDPOINT_KEY = "HubEndpoint";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();

string clientUrl = builder.Configuration.GetSection(CLIENT_URL_CONFIG_KEY).Value;

builder.Services.AddCors(setup =>
{
    setup.AddPolicy(POLICY_CORS,
        policy =>
        {
            policy.WithOrigins(clientUrl);
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowCredentials();
            
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(POLICY_CORS);

app.UseHttpsRedirection();

string hubEndpoint = app.Configuration.GetSection(HUB_ENDPOINT_KEY).Value;  
app.MapHub<ChatHub>(hubEndpoint);

app.Run();
