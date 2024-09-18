namespace RestClient.Parser;

public interface IFileParser
{
    ParsedFileData ParseFile(FileInfo file);
}
public interface IDirectoryParser
{
    IEnumerable<ParsedFileData> ParseDir(DirectoryInfo dir);
}
/// <summary>
/// Представляет модель данных распаршенного файла.
/// </summary>
public record ParsedFileData(IEnumerable<HttpRequestMessage> Requests, Models.RequestsContext Context);
