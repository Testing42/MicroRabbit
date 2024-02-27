using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Infra.IoC;
using System.Reflection;
using MicroRabbit.Transfer.Data.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
//this setup for the db context connection was needed to preform get from the database
builder.Services.AddDbContext<BankingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDbConnection"));
});


// Registering services from DependencyContainer
DependencyContainer.RegisterServices(builder.Services, builder.Configuration);

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Banking Microservice", Version = "v1" });
});

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
