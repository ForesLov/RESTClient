using RestClient.Parser.Contracts;

namespace RestClient.Parser.Tokens;


public class CommentToken : IEmptyToken
{
    public override bool Equals(object? obj)
    {
        if (obj is CommentToken c)
            return Equals(c);
        return false;
    }
    public bool Equals(CommentToken obj)
    {
        return CommentaryText == obj.CommentaryText;
    }
    public CommentToken(string commentaryText)
    {
        CommentaryText = commentaryText;
    }

    public readonly string CommentaryText;

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
