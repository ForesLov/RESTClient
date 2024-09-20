namespace RestClient.Parser;

public record class ParseState(HttpRequestMessage? LastRequest, bool BodyParsing = false)
{
    public ParseState NewRequest(HttpRequestMessage r) => this with { LastRequest = r };
    public ParseState StartBody()
    {
        if (RequestInitialized)
            return this with { BodyParsing = true };

        return this;
    }
    public bool RequestInitialized => LastRequest is not null;

    public ParseState BreakRequest() => this with { LastRequest = null };
}
