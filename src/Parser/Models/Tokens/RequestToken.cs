using RestClient.Parser.Contracts;

namespace RestClient.Parser.Models.Tokens;

public class RequestToken : IRequestToken
{
    private readonly string _text;

    public RequestToken(string text)
    {
        _text = text;
    }
    public bool Equals(RequestToken obj)
    {
        return _text == obj._text;
    }
    public void Execute(HttpRequestMessage request)
    {
        var words = _text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length < 2)
            throw new Exception("Too small");

        var methodResolver = new HttpMethodResolver();
        request.Method = methodResolver.Resolve(words[0]);
        request.RequestUri = new Uri(words[1]);

        if (words.Length >= 3)
        {
            var versionResolver = new HttpVersionResolver();
            request.Version = versionResolver.Resolve(words[2]);
        }
        // TODO: finnish implementation
    }

    #region Overrides

    public override bool Equals(object? obj)
    {
        if (obj is RequestToken c)
            return Equals(c);
        return false;
    }

    public override int GetHashCode()
    {
        return _text.GetHashCode();
    }

    public override string? ToString()
    {
        return _text;
    }

    #endregion
}
