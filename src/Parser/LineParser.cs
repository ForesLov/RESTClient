using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Parser;

public class LineParser
{
    private readonly string _line;

    public LineParser(string Line)
    { 
        _line = Line;
    }
    public ParsedData? Parse()
    {
        if (string.IsNullOrEmpty(_line))
        {
            return null;
        }
        if (_line.StartsWith("###"))
            return new Comment(_line, true);
        if (_line.StartsWith("#") || _line.StartsWith("//"))
            return new Comment(_line, false);
        else
            return new RequestData(_line);
    }
}
public abstract class ParsedData
{

}
public class Comment : ParsedData
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
public class RequestData : ParsedData
{
    public override bool Equals(object? obj)
    {
        if (obj is RequestData c)
            return Equals(c);
        return false;
    }
    public bool Equals(RequestData obj)
    {
        return Text == obj.Text;
    }
    public readonly string Text;

    public RequestData(string requestDataText)
    {
        Text = requestDataText;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}