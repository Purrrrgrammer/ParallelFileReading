using ParallelFileReading.Models;

namespace ParallelFileReading.Services;

public interface IDirectoryAnalyzer
{
    Task<DirectoryAnalysisResult> AnalyseDirectoryAsync(string directoryPath, CancellationToken cancellationToken);
}