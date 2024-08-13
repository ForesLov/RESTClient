namespace RestClient.Parser.Models;

public class Request
{
    public string Url { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
    public string Body { get; set; }

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
