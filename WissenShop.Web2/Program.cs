using WissenShop.Web.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();