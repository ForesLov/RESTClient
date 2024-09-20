using RestClient.Parser.Contracts;

namespace RestClient.Parser.Models.Tokens;

public class EmptyToken : IEmptyToken
{
    public static EmptyToken Default { get; } = new();
    private EmptyToken() { }
}
