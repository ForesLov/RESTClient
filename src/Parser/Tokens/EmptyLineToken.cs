using RestClient.Parser.Contracts;

namespace RestClient.Parser.Tokens;

public class EmptyLineToken : IRequestToken
{
    public ParseState Execute(ParseState state) => state.StartBody();
}

