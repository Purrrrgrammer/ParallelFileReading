namespace ParallelFileReading.Services;

public class SpaceCounter : ISpaceCounter
{
    public async Task<Models.FileInfo> CountNumberOfSpacesInFileAsync(
        string filePath, 
        CancellationToken cancellationToken)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");
        
        int spaceCount = 0;
        char[] buffer = new char[4096];
        int charsRead;
        
        using var streamReader = new StreamReader(filePath);
        
        while ((charsRead = await streamReader.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            for (int i = 0; i < charsRead; i++)
            {
                if (buffer[i] == ' ') spaceCount++;
            }
        }
        
        return new(filePath, spaceCount);
    }
}