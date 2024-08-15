namespace RestClient.Parser;

public class HttpVersion
{
    private readonly decimal _version;
    public HttpVersion(decimal version)
    {
        _version = version;
    }
    public override string ToString() => $"HTTP/{_version}";
}
