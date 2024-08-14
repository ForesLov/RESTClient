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
                Url = "http://localhost:{{host}}",
                Method = HttpMethod.Get,
            }
        ];

        var ctx = new RequestsContext
        {
            Variables =
            [
                new("host", "1236"),
                new("token", "my-cool-token")
            ],
        };

        return new ParsedFileData(requests, ctx);
    }
}
