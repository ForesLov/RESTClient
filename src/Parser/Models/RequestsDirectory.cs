namespace RestClient.Parser.Models;

public record RequestsDirectory(
    DirectoryInfo Directory,
    IEnumerable<RequestsList> Files
);
