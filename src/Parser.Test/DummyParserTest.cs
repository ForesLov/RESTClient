namespace Parser.Test;

public class DummyParserTest
{
    [Fact]
    public void Test1()
    {
        var parser = new DummyFileParser();
        var result = parser.ParseFile(null);

        var workingRequest = result.Requests.First();

        workingRequest.Should().NotBeNull();

        var buildedUrl = workingRequest.BuildUrl(result.Context);
        //Console.WriteLine(buildedUrl);
        buildedUrl.Should().BeEquivalentTo("http://localhost:1236");

        //Console.WriteLine(workingRequest.BuildRequest(result.Context));

        Assert.True(result.Requests.Count() == 1, "Should be only one request");
    }
}
