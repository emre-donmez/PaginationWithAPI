using Microsoft.EntityFrameworkCore;
using PaginationAPI.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NycTaxiContext>(options => options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
     options.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod());

app.MapControllers();

app.Run();