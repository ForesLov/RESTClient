using RestClient.Parser.Models;

namespace RestClient.Parser;

public interface IFileParser
{
    RequestsList ParseFile(FileInfo file);
}
public interface IDirectoryParser
{
    RequestsDirectory ParseDir(DirectoryInfo dir);
}
