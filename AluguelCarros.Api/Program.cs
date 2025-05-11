using AluguelCarros.Api.Middleware;
using AluguelCarros.Application;
using AluguelCarros.Application.Validators.Behaviors;
using AluguelCarros.Infrastructure.Data;
using AluguelCarros.Infrastructure.Data.Repositories;
using AluguelCarros.Domain.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(typeof(ApplicationAssemblyReference).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyReference).Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));

builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();