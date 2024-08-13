using System.Collections;

namespace RestClient.Parser.Models;

public record RequestsList(
    IEnumerable<Request> Requests,
    RequestsContext Context
) : IEnumerable<Request>
{
    public IEnumerator<Request> GetEnumerator()
    {
        return Requests.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Requests.GetEnumerator();
    }
}
