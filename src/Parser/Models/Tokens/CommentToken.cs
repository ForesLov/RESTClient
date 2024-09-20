using RestClient.Parser.Contracts;

namespace RestClient.Parser.Models.Tokens;


public class Comment : IEmptyToken
{
    public override bool Equals(object? obj)
    {
        if (obj is Comment c)
            return Equals(c);
        return false;
    }
    public bool Equals(Comment obj)
    {
        return CommentaryText == obj.CommentaryText && IsInterrupt == obj.IsInterrupt;
    }
    public Comment(string commentaryText, bool isInterrupt = false)
    {
        CommentaryText = commentaryText;
        IsInterrupt = isInterrupt;
    }

    public readonly string CommentaryText;
    public readonly bool IsInterrupt;

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
