namespace RestClient.Parser.Models;

public class Request
{
    public HttpMethod Method { get; set; }
    public HttpVersion? Version { get; set; }
    public string Url { get; set; }
    public Dictionary<string, string> UrlParameters { get; set; }
    public string Body { get; set; }
    public Dictionary<string, string> Headers { get; set; }

    /// <summary>
    /// Return url with all variables (environment and file scoped) inserted
    /// </summary>
    /// <param name="ctx"></param>
    /// <returns></returns>
    public string BuildUrl(RequestsContext ctx)
    {
        // TODO: implement method
        return Url;
    }
}
