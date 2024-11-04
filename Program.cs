using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using QBank.Data;
using QBank.Services;
using QBank.Filters;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext com a string de conexão
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registra os Serviços
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<TokenAuthorizeFilter>();

// Adiciona suporte para controllers e filtros
builder.Services.AddControllers();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
