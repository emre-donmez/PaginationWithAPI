using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaginationDemo.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NyctaxiSampleContext>(options => options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

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
