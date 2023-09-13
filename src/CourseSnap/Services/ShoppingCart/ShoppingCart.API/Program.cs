using ShoppingCart.Infrastructure;
using ShoppingCart.Application;
using ShoppingCart.API.Grpc;
using GrpcServer.Protos;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServiceDependency(builder.Configuration);

var app = builder.Build();
app.ConfigureExceptionMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
