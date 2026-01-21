using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Commands.Transactions;
using MyFinance.Domain.Repositories;
using MyFinance.Domain.Services.Implementations;
using MyFinance.Domain.Services.Interfaces;
using MyFinance.Infrastructure.DbContexts;
using MyFinance.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --- 1. Agregar el Servicio CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200", "https://localhost:7291")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateTransactionCommand>());

builder.Services.AddDbContext<MyFinanceDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySQLConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
