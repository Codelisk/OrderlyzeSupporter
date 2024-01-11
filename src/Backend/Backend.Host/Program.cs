using Backend.Host;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureDatabase();

builder.Services.AddAutoMapper();
builder.Services.AddAllServices();

builder.Build().Configure();

Console.WriteLine("Start finished");