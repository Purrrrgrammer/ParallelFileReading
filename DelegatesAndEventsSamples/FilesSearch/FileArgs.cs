namespace DelegatesAndEventsSamples.FilesSearch;

public class FileArgs : EventArgs
{
    public required string FileName { get; init; }
    public bool Cancel { get; set; }
}