namespace RestClient.Parser.Contracts;

public interface IRequestToken : IToken
{
    ParseState Execute(ParseState state);
}
