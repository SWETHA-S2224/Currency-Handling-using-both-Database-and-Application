using Microsoft.EntityFrameworkCore;
using WebApi6.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PropContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
