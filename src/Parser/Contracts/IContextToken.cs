using RestClient.Parser.Models;

namespace RestClient.Parser.Contracts;

public interface IContextToken : IToken
{
    void Execute(RequestsContext ctx);
}
