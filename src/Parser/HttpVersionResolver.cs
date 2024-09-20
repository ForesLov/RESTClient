namespace RestClient.Parser;

public class HttpVersionResolver
{
    public const string Prefix = "HTTP/";
    public Version Resolve(string value)
    {
        if (!value.StartsWith(Prefix))
            throw new Exception("Wrong HTTP version format");

        // Prevent exception for not '2.0' but '2' cases
        if (!value.Any(c => c == '.'))
        {
            value = value + ".0";
        }

        return Version.Parse(value.Replace(Prefix, ""));
    }
}
