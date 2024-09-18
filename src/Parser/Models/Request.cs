using System.Text;

namespace RestClient.Parser.Models;

/// <summary>
/// Probably deprecated
/// </summary>
public class Request
{
    public HttpMethod Method { get; set; }
    public HttpVersion? Version { get; set; }
    public string Url { get; set; }
    public Dictionary<string, string> UrlParameters { get; set; }
    public string Body { get; set; }
    public Dictionary<string, string> Headers { get; set; } = new();

    /// <summary>
    /// Return url with all variables (environment and file scoped) inserted
    /// </summary>
    /// <param name="ctx"></param>
    /// <returns></returns>
    public string BuildUrl(RequestsContext ctx)
    {
        // TODO: implement method
        var sb = new StringBuilder(Url);
        foreach (var variable in ctx.Variables)
        {
            // TODO: Replace with more cooler pattern matching (currently string '{{ host }}', won't be replaced)
            sb.Replace($"{{{{{variable.Name}}}}}", variable.Value);
        }
        return sb.ToString();
    }

    public HttpRequestMessage BuildRequest(RequestsContext ctx)
    {
        var r = new HttpRequestMessage();
        r.Method = Method;
        r.RequestUri = new Uri(BuildUrl(ctx));
        r.Headers.Clear();
        foreach (var header in Headers)
        {
            r.Headers.Add(header.Key, header.Value);
        }

        return r;
    }
}
