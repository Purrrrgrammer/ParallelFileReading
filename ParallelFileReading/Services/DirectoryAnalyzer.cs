using System.Diagnostics;
using ParallelFileReading.Models;

namespace ParallelFileReading.Services;
public class DirectoryAnalyzer(
    IDirectoryScanner directoryScanner, 
    ISpaceCounter spaceCounter) : IDirectoryAnalyzer
{
    public async Task<DirectoryAnalysisResult> AnalyseDirectoryAsync(
        string directoryPath, 
        CancellationToken cancellationToken)
    {
        Stopwatch stopWatch = new Stopwatch();
        
        stopWatch.Start();
        
        string[] filePaths = directoryScanner.GetFiles(directoryPath);
        
        var tasks = filePaths
            .Select(path => spaceCounter.CountNumberOfSpacesInFileAsync(path, cancellationToken))
            .ToList();
        
        var results = await Task.WhenAll(tasks);
        var totalSpacesCount = results.Sum(info => info.SpaceCount);
        
        stopWatch.Stop();
        
        return new(results, stopWatch.Elapsed, totalSpacesCount);
    }
}