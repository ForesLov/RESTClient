using RestClient.Parser.Models;

namespace RestClient.Parser;

public interface IFileParser
{
    ParsedFileData ParseFile(FileInfo file);
}
public interface IDirectoryParser
{
    RequestsDirectory ParseDir(DirectoryInfo dir);
}

public record ParsedFileData(IEnumerable<Models.Request> Requests, Models.RequestsContext Context);
