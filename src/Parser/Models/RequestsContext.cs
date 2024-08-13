namespace RestClient.Parser.Models;

public class RequestsContext
{
    public IEnumerable<Variable> Variables {get;set;}
}

public record Variable(string Name, string Value);
