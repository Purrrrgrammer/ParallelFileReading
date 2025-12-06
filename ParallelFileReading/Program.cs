using ParallelFileReading.Services;

namespace ParallelFileReading;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Enter directory path:");
        var directoryPath = Console.ReadLine();

        if (string.IsNullOrEmpty(directoryPath))
        {
            Console.WriteLine("Directory path is wrong");
            return;
        }   
        
        IDirectoryAnalyzer directoryAnalyzer = new DirectoryAnalyzer(new DirectoryScanner(), new SpaceCounter());
        
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));
        
        var result = await directoryAnalyzer.AnalyseDirectoryAsync(directoryPath, cancellationTokenSource.Token);
        
        foreach (var fileInfo in result.FilesInfos)
        {
            Console.WriteLine($"Path = {fileInfo.Path}; SpaceCount = {fileInfo.SpaceCount}");
        }
        
        Console.WriteLine($"TotalSpacesCount = {result.TotalSpacesCount}");
        Console.WriteLine($"ExecutionTime = {result.ExecutionTime}");
    }
}