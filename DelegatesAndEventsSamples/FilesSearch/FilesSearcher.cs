namespace DelegatesAndEventsSamples.FilesSearch;

public sealed class FilesSearcher
{
    public delegate void FileFoundHandler(object sender, FileArgs e);
    public event FileFoundHandler? FileFound;

    public void Search(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
            throw new DirectoryNotFoundException($"Directory not exists: {directoryPath}");

        var files = Directory.GetFiles(directoryPath);

        foreach (var file in files)
        {
            var args = new FileArgs() { FileName = file };
            FileFound?.Invoke(this, args);
            if(args.Cancel) break;
        }
    }
}