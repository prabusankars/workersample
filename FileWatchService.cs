namespace workersample;

public class FileWatchService{
    private readonly ILogger<FileWatchService> logger;

    public FileWatchService(ILogger<FileWatchService> _logger){
        logger = _logger;
        this.FileWatchStarted = false;
    }

    public async Task<bool> StartFileWatcher(){
        FileSystemWatcher fileSysWatcher = new FileSystemWatcher();
        fileSysWatcher.Filter="*.*";
        fileSysWatcher.Path ="./monitorfolder";
        fileSysWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        fileSysWatcher.Created += async (sender,fileSysArgs) =>{
            logger.LogInformation(String.Format("file Created :{0}",fileSysArgs.FullPath));
            // TODO handling of file event
            // async executefileevent(string filepath) ;
            // ----------------------------------------
        };
        fileSysWatcher.EnableRaisingEvents = true;
        this.FileWatchStarted = true;
        logger.LogInformation("File Watch Started");
        return true;
    } 

    public bool FileWatchStarted {get;set;}

}