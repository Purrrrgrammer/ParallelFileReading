using DelegatesAndEventsSamples.FilesSearch;
using DelegatesAndEventsSamples.MaxElementSearch;
using ParallelFileReading.Services;

namespace ParallelFileReading;

class Program
{
    public static async Task Main()
    {
        ShowMaxElementSearchSample();
        ShowFilesSearchSample();
    }

    private static void ShowFilesSearchSample()
    {
        Console.WriteLine("Enter directory path:");
        var directoryPath = Console.ReadLine();

        if (string.IsNullOrEmpty(directoryPath))
        {
            Console.WriteLine("Directory path is wrong");
            return;
        }   
        
        var searcher = new FilesSearcher();

        searcher.FileFound += OnFileFound;
        searcher.Search(directoryPath);
        searcher.FileFound -= OnFileFound;
    }

    private static void OnFileFound(object sender, FileArgs e)
    {
        Console.WriteLine($"sender : {sender.GetType().Name}; fileName = {e.FileName}");
        
        if (Path.GetExtension(e.FileName) == ".cs")
        {
            e.Cancel = true;
        }
    }

    private static void ShowMaxElementSearchSample()
    {
        List<string> numbers = ["23", "45,56", "28", "-55", "45,566"];
        Console.WriteLine(numbers.GetMax((x) => float.Parse(x)));
    }
    
    private static async Task ShowParallelReadingSample()
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