using workersample;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSerilog(config => { config.ReadFrom.Configuration(builder.Configuration); });
builder.Services.AddSingleton<FileWatchService>();
builder.Services.AddHostedService<Worker>();
var host = builder.Build();
host.Run();
