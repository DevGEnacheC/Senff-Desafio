using AluguelCarros.Api.Middleware;
using AluguelCarros.Application;
using AluguelCarros.Application.Validators.Behaviors;
using AluguelCarros.Infrastructure.Data;
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