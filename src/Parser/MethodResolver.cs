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
        var method = str.Trim().ToUpper() switch
        {
            "GET" => HttpMethod.Get,
            "POST" => HttpMethod.Post,
            "PUT" => HttpMethod.Put,
            "PATCH" => HttpMethod.Patch,
            "DELETE" => HttpMethod.Delete,
            "HEAD" => HttpMethod.Head,
            "TRACE" => HttpMethod.Trace,
            "CONNECT" => HttpMethod.Connect,
            _ => _defaultMethod,
        };

        return method;
    }
}
