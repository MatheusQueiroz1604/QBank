using Microsoft.EntityFrameworkCore;

using QBank.Data;
using QBank.DTOs;
using QBank.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

AccountRoutes.MapAccountRoutes(app);
TransactionRoutes.MapTransactionRoutes(app);
UserRoutes.MapUserRoutes(app);

app.Run();
