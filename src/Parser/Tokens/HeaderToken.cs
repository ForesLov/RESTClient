using RestClient.Parser.Contracts;

namespace RestClient.Parser.Tokens;

public class HeaderToken : IRequestToken
{
    private readonly string _text;

    public HeaderToken(string text)
    {
        _text = text;
    }

    public ParseState Execute(ParseState state)
    {
        if (!state.RequestInitialized)
            throw new Exception("Can't add header for unknown request");

        var words = _text.Trim().Split(':', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (words.Length < 2)
            throw new Exception("Wrong header format");

        state.LastRequest?.Headers.Add(words[0], words[1]);
        return state;
    }
}
