using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
//this setup for the db context connection was needed to preform get from the database
builder.Services.AddDbContext<TransferDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"));
});



// Registering services from DependencyContainer
DependencyContainer.RegisterServices(builder.Services, builder.Configuration);


// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Transfer Microservice", Version = "v1" });
});

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

ConfigureEventBus(app);

app.Run();

static void ConfigureEventBus(WebApplication app)
{
    var eventBus = app.Services.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
}