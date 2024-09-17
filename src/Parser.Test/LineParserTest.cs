using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Test
{
    public class LineParserTest
    {


        [Fact]
        void ParseCommentsTest()
        {
            string[] testData = { "//", "#", "###" };
            object[] controlData =
            {
                new Comment("//"),
                new Comment("#"),
                new Comment("###", true),
            };
            object[] parsedData = new object[testData.Length];
            for (int i = 0; i <= testData.Length - 1; i++)
            {
                parsedData[i] = new LineParser(testData[i]).Parse();
            }

            Assert.Equal(controlData, parsedData);
        }
        [Fact]
        void PaseLineInterruptTest()
        {
            string[] testData = { "#", "###" };
            Comment[] controlData =
            {
                new Comment("#"),
                new Comment("###", true),
            };
            object[] parsedData = new object[testData.Length];
            for (int i = 0; i < testData.Length; i++)
            {
                parsedData[i] = new LineParser(testData[i]).Parse();
            }
            Assert.Equal(controlData, parsedData);
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
