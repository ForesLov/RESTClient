using RestClient.Backend.Contracts;

namespace RestClient.Backend;


public class HistoryProvider : IHistoryProvider
{
    private const string HistoryFileName = ".ru.is2-19.rest-client_history";
    private FileInfo HistoryFile
    {
        get
        {
            var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var historyFile = Path.Combine(homeDir, HistoryFileName);
            return new(historyFile);
        }
    }

    public IEnumerable<DirectoryInfo> GetLast10()
    {
        return GetHistory().TakeLast(10);
    }

    private IEnumerable<DirectoryInfo> GetHistory()
    {
        var stream = HistoryFile.OpenText();
        while (!stream.EndOfStream)
        {
            var dir = ReadDir(stream);

            if (dir is not null)
                yield return dir;
        }
    }

    public DirectoryInfo? GetLast()
    {
        var stream = HistoryFile.OpenText();
        return GetHistory().LastOrDefault();
    }

    public Task AppendAsync(DirectoryInfo dir)
    {
        var fs = HistoryFile.OpenWrite();
        var writer = new StreamWriter(fs);

        return writer.WriteLineAsync(dir.FullName);
    }
    public void Append(DirectoryInfo dir)
    {
        var fs = HistoryFile.OpenWrite();
        var writer = new StreamWriter(fs);

        writer.WriteLine(dir.FullName);
    }
    public void Delete(DirectoryInfo dir)
    {
        var newHistory = GetHistory().Distinct().Except([dir]);
        HistoryFile.Delete();
        var writter = new StreamWriter(HistoryFile.OpenWrite());

        foreach (var d in newHistory)
        {
            writter.WriteLine(dir.FullName);
        }
    }

    private static DirectoryInfo? ReadDir(StreamReader s)
    {
        var line = s.ReadLine();

        if (!string.IsNullOrWhiteSpace(line))
            return new DirectoryInfo(line);

        return null;
    }
}
