using FileCreateWorkerService;
using FileCreateWorkerService.Models;
using FileCreateWorkerService.Services;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        IConfiguration Configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            
        services.AddSingleton<RabbitMQClientService>();
        services.AddDbContext<AdventureWorks2019Context>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
        });
        services.AddSingleton(sp => new ConnectionFactory()
        {

           

            Uri = new Uri(Configuration.GetConnectionString("RabbitMQ")),
            DispatchConsumersAsync = true
        });

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
