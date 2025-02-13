using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Data;

var builder = WebApplication.CreateBuilder(args);
string connectionString = "Host=localhost;Database=ecommerce;Username=postgres;Password=suasenha";

// Config do db
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();