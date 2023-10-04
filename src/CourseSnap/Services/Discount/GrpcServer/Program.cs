using GrpcServer.GrpcService;
using Discount.Infrastructure;
using Discount.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
builder.Services.AddInfrastructureServices(builder.Configuration);
var app = builder.Build();

app.MapGrpcService<DiscountGrpc>();
app.Run();
