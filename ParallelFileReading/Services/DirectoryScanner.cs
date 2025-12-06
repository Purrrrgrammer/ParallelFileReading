namespace ParallelFileReading.Services;

public class DirectoryScanner : IDirectoryScanner
{
    public string[] GetFiles(string directory)
    {
        if (!Directory.Exists(directory))
            throw new DirectoryNotFoundException($"Directory not exists: {directory}");

        return Directory.GetFiles(directory);
    }
}