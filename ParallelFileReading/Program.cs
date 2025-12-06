using ParallelFileReading.Services;

namespace ParallelFileReading;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter directory path:");

        List<string> filePaths = new List<string>()
        {
            "C:\\Nastya\\MyProjects\\ParallelFileReading\\ParallelFileReading\\TestFiles\\Текстовый документ.txt",
            "C:\\Nastya\\MyProjects\\ParallelFileReading\\ParallelFileReading\\TestFiles\\Текстовый документ (2).txt",
            "C:\\Nastya\\MyProjects\\ParallelFileReading\\ParallelFileReading\\TestFiles\\Текстовый документ — копия.txt"
        };

        ISpaceCounter spaceCounter = new SpaceCounter();

        List<Task<Models.FileInfo>> tasks = new List<Task<Models.FileInfo>>();

        for (int i = 0; i < filePaths.Count; i++)
        {
            var currentFilePath = filePaths[i];
            tasks.Add(spaceCounter.CountNumberOfSpacesInFileAsync(currentFilePath));
        }
        
        var results = await Task.WhenAll(tasks);

        foreach (var result in results)
        {
            Console.WriteLine($"{result.Path} : spaces count = {result.SpaceCount}");
        }
    }
}