namespace RestClient.Parser.Models;

public class RequestsContext
{
    public IEnumerable<Variable> Variables { get; set; } = new List<Variable>();
}

public record Variable(string Name, string Value);
