using RestClient.Parser.Contracts;

namespace RestClient.Parser;

public class Parser
{
    private readonly FileInfo _file;

    public Parser(FileInfo file)
    {
        _file = file;
    }

    public IEnumerable<HttpRequestMessage> Parse()
    {
        using var reader = new StreamReader(_file.OpenRead());
        var tokens = new List<IToken>();
        while (!reader.EndOfStream)
        {
            tokens.Add(LineParser.Parse(reader.ReadLine()));
        }
        //
        var requests = new List<HttpRequestMessage>();

        var state = new ParseState(null);

        foreach (var t in tokens)
        {
            if (t is IRequestToken requestToken)
            {
                var newState = requestToken.Execute(state);
                if (newState.LastRequest is not null && newState.LastRequest != state.LastRequest)
                {
                    state = newState;
                    requests.Add(state.LastRequest);
                }
                // TODO: remove this nestings
            }
        }

        return requests;
    }
}
