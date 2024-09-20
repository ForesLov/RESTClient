using RestClient.Parser.Contracts;
using RestClient.Parser.Models.Tokens;

namespace RestClient.Parser;

public class LineParser
{
    private readonly string _line;

    public LineParser(string line)
    {
        _line = line;
    }
    public IToken? Parse()
    {
        if (string.IsNullOrEmpty(_line))
        {
            return EmptyToken.Default;
        }
        if (_line.StartsWith("###"))
            return new Comment(_line, true);
        if (_line.StartsWith("#") || _line.StartsWith("//"))
            return new Comment(_line, false);
        else
            return new RequestToken(_line);
    }
}
