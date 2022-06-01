using Microsoft.EntityFrameworkCore;
using North.Businesss.Repositories;
using North.Businesss.Repositories.Abstracts;
using North.Core.Entities;
using North.Data;

var builder = WebApplication.CreateBuilder(args);
var con1 = builder.Configuration.GetConnectionString("Con1");

builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer(con1);
});

builder.Services.AddScoped<IRepository<Category,int>, CategoryRepo>();
builder.Services.AddScoped<IRepository<Product,int>, ProductRepo>();
builder.Services.AddScoped<IRepository<Order,int>, OrderRepo>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
