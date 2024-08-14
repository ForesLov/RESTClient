using RestClient.Parser.Models;

namespace RestClient.Parser;

public class DummyFileParser : IFileParser
{
    public ParsedFileData ParseFile(FileInfo file)
    {
        Request[] requests =
        [
            new Request
            {
                Url = "http://localhost:{{port}}",
                Method = HttpMethod.Get,
            }
        ];

        var ctx = new RequestsContext
        {
            Variables =
            [
                new("port", "1236"),
                new("token", "my-cool-token")
            ],
        };

        return new ParsedFileData(requests, ctx);
    }
}
