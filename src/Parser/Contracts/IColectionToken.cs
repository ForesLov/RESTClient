namespace RestClient.Parser.Contracts;

public interface ICollectionToken : IToken
{
    IEnumerable<HttpRequestMessage> Execute(IEnumerable<HttpRequestMessage> collection);
}
