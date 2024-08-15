namespace RestClient.Parser;

internal class MethodResolver
{
    private readonly HttpMethod _defaultMethod;

    public MethodResolver(HttpMethod? defaultMethod = null)
    {
        _defaultMethod = defaultMethod ?? HttpMethod.Get;
    }

    public HttpMethod Resolve(string str)
    {
        var method = str.ToUpper() switch
        {
            "GET" => HttpMethod.Get,
            _ => _defaultMethod,
        };

        return method;
    }
}
