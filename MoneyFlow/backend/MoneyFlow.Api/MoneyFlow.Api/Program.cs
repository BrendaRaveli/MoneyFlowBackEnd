using Microsoft.EntityFrameworkCore;
using MoneyFlow.Api.Data;
using MoneyFlow.Api.Repositories;
using MoneyFlow.Api.Services;
using MoneyFlow.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Configuração de CORS (NOVO)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // URL padrão do Angular
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Database
builder.Services.AddDbContext<MoneyFlowDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Ativar CORS (NOVO)
app.UseCors("AllowAngular");

// O Middleware de erro deve ser o primeiro do pipeline
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
