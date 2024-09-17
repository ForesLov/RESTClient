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
    public Comment(string commentaryText, bool isInterrupt = false)
    {
        CommentaryText = commentaryText;
        IsInterrupt = isInterrupt;
    }

    public readonly string CommentaryText;
    public readonly bool IsInterrupt;
}
public class RequestData : ParsedData
{
    public readonly string RequestDataText;

    public RequestData(string requestDataText)
    {
        RequestDataText = requestDataText;
    }
}