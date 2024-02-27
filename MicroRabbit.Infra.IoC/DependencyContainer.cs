using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.EventHandlers;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Domain banking commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //domain events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            // Application services
            services.AddTransient<IAccountService, AccountService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();

            // Register BankingDbContext with proper configuration
            services.AddDbContext<BankingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BankingDbConnection")));


            // Register TransferDbContext with proper configuration
            services.AddDbContext<TransferDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TransferDbConnection")));

            // Assuming these services are needed here, which is typically not the case in a well-separated microservices design
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<ITransferService, TransferService>();
        }
    }
}
