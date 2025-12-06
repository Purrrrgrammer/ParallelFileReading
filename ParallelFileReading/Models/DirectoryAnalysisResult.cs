namespace ParallelFileReading.Models;

public record DirectoryAnalysisResult(
    IReadOnlyCollection<FileInfo> FilesInfos,
    TimeSpan ExecutionTime,
    int TotalSpacesCount);
