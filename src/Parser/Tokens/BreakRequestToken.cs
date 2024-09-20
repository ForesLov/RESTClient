using RestClient.Parser.Contracts;

namespace RestClient.Parser.Tokens;

public class BreakRequestToken : IRequestToken
{
    public ParseState Execute(ParseState state)
    {
        return state.BreakRequest();
    }
}
