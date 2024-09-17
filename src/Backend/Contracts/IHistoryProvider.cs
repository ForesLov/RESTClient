namespace RestClient.Backend.Contracts;

public interface IHistoryProvider
{
    IEnumerable<DirectoryInfo> GetLast10();
    DirectoryInfo? GetLast();
    void Append(DirectoryInfo dir);
    Task AppendAsync(DirectoryInfo dir);
    void Delete(DirectoryInfo dir);
}
