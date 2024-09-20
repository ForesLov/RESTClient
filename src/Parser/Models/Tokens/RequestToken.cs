using RestClient.Parser.Contracts;

namespace RestClient.Parser.Models.Tokens;

public class RequestToken : IRequestToken
{
    public readonly string Text;

    public RequestToken(string requestDataText)
    {
        Text = requestDataText;
    }
    public bool Equals(RequestToken obj)
    {
        return Text == obj.Text;
    }
    public void Execute(HttpRequestMessage request)
    {
        var words = Text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
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

        throw new NotImplementedException(); // TODO: implement
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
        return Text.GetHashCode();
    }

    public override string? ToString()
    {
        return Text;
    }

    #endregion
}
