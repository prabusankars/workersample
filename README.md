Worker Service runs in behind to monitor the folder for files.

There is a problem in the monitoring.


//to add serilog to .NET 8.0

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog(config => { config.ReadFrom.Configuration(builder.Configuration); });

builder.Services.AddHostedService<Worker>();

