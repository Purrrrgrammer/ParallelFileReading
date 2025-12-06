namespace ParallelFileReading.Services;

public class SpaceCounter : ISpaceCounter
{
    public async Task<Models.FileInfo> CountNumberOfSpacesInFileAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return null; //Task<int>.FromResult(0);
        }
        
        int spaceCount = 0;
        char[] buffer = new char[4096];
        int charsRead;
        
        using var streamReader = new StreamReader(filePath);
        
        while ((charsRead = await streamReader.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            for (int i = 0; i < charsRead; i++)
            {
                if (buffer[i] == ' ') spaceCount++;
            }
        }
        
        return new Models.FileInfo() { SpaceCount = spaceCount, Path = filePath };
    }
}