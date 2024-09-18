using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.Parser;

namespace Parser.Test
{
    public class LineParserTest
    {
        [Theory, InlineData("//", false), InlineData("#", false), InlineData("###", true)]
        void ParseCommentsTest(string value, bool IsInterrupt)
        {
            var expectedData = new Comment(value, IsInterrupt);
            LineParser lineParser = new LineParser(value);
            Assert.Equal(expectedData, lineParser.Parse());
        }

        [Fact]
        void ParseRequestDataTest()
        {
            string testData = "GET /index.html HTTP/1.1";
            RequestData controlData = new RequestData(testData);
            var parsedData = new LineParser(testData).Parse();
            Assert.Equal(controlData, parsedData);
        }
    }
}
