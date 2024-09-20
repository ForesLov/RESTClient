namespace RestClient.Parser.Contracts;

public interface IRequestToken : IToken
{
    void Execute(HttpRequestMessage request);
}
