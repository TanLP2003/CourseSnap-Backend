using JwtSetup;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                                    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true)
                                    .Build();
builder.Services.AddOcelot(configuration);
builder.Services.ConfigureJwt(builder.Configuration);

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
await app.UseOcelot();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
