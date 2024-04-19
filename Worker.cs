namespace workersample;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    //Inject FileWatchService
    private readonly FileWatchService fwService;

    public Worker(ILogger<Worker> logger, FileWatchService _fws)
    {
        _logger = logger;
        fwService = _fws;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            if(!fwService.FileWatchStarted){
                _logger.LogInformation("Staring FileWatch on folder");
                await fwService.StartFileWatcher();
            }

            await Task.Delay(60000, stoppingToken);
        }
    }
}
