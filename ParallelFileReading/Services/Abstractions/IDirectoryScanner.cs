namespace ParallelFileReading.Services;

public interface IDirectoryScanner
{
    string[] GetFiles(string directory);
}