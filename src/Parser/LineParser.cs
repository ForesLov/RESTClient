using System.Text.RegularExpressions;
using RestClient.Parser.Contracts;
using RestClient.Parser.Tokens;

namespace RestClient.Parser;

public class LineParser
{
    private static Regex RequestUriRegex = new("(GET)|(POST)|(PUT)|(PATCH)|(DELETE)|(HEAD)|(TRACE)|(CONNECT) [\\S]+ (HTTP\\/[\\d])", RegexOptions.Compiled);
    private static Regex BreakRequestRegex = new("^[ \\t]*###", RegexOptions.Compiled);
    private static Regex HeaderRegex = new("^[\\S]+:[.]*", RegexOptions.Compiled);
    private static Regex CommentRegex = new("^[\\s]*[#]|(\\/\\/)", RegexOptions.Compiled);

    private readonly string _line;

    public LineParser(string line)
    {
        _line = line;
    }
    public IToken? Parse()
    {
        if (BreakRequestRegex.Match(_line).Success)
            return new BreakRequestToken();

        if (HeaderRegex.Match(_line).Success)
            return new HeaderToken(_line);

        if (RequestUriRegex.Match(_line).Success)
            return new RequestToken(_line);

        if (CommentRegex.Match(_line).Success)
            return new CommentToken(_line);

        if (string.IsNullOrWhiteSpace(_line))
            return new EmptyLineToken();

        return EmptyToken.Default;
    }
}
