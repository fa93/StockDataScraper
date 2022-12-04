using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataScraper.Main;
using DataScraper.Main.DbContexts;
using DataScraper.Worker;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var migrationAssemblyName = typeof(Worker).Assembly.FullName;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();


try
{
    Log.Information("Application Starting up");

    IHost host = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .UseSerilog()
    .ConfigureContainer<ContainerBuilder>(builder =>
    {

        builder.RegisterModule(new WorkerModule(connectionString, migrationAssemblyName));
        builder.RegisterModule(new MainModule(connectionString, migrationAssemblyName));

    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<DseDbContext>(option =>
                    option.UseSqlServer(connectionString,
                        b => b.MigrationsAssembly(migrationAssemblyName)));
    })
    .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}

