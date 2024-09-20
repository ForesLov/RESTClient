using RestClient.Parser.Contracts;

namespace RestClient.Parser.Models.Tokens;

public class RequestToken : IToken
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
