using RestClient.Parser.Contracts;
using RestClient.Parser.Models.Tokens;

namespace Parser.Test
{
    public class LineParserTest
    {
        [Theory]
        [InlineData("//", false)]
        [InlineData("#", false)]
        [InlineData("###", true)]
        void ParseCommentsTest(string value, bool isInterrupt)
        {
            var expectedData = new Comment(value, isInterrupt);
            LineParser lineParser = new LineParser(value);
            lineParser.Parse().Should().BeEquivalentTo(expectedData);
        }

        [Theory]
        [InlineData("GET /index.html HTTP/1.1")]
        [InlineData("POST /index.html")]
        [InlineData("  POST /index.html/with-spaces")]
        [InlineData("\tPOST /index.html/with-tab")]
        void ParseRequestDataTest(string requestStr)
        {
            IToken controlData = new RequestToken(requestStr);
            var parsedData = new LineParser(requestStr).Parse();
            controlData.Should().BeEquivalentTo(controlData);
        }
    }
}
