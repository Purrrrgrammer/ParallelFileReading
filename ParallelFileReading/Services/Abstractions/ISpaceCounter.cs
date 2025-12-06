using FileInfo = ParallelFileReading.Models.FileInfo;

namespace ParallelFileReading.Services;

public interface ISpaceCounter
{
    Task<FileInfo> CountNumberOfSpacesInFileAsync(string filePath, CancellationToken cancellationToken);
}