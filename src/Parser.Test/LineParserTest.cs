using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Test
{
    public class LineParserTest
    {
        string [] testData = { "//", "#", "GET /index.html HTTP/1.1" };
        List<string> CommentsControl = new List<string>();
        List<string> Comments = new List<string>();
        List<string> BodiesControl = new List<string>();
        List<string> Bodies = new List<string>();
        [Fact]
        void TestBodie()
        {
            for (int i = 0; i < testData.Length - 1; i++)
            {
                if (i < 2)
                    CommentsControl.Add(testData[i]);
                else
                    BodiesControl.Add(testData[i]);
            }
            LineParser lineParser = new LineParser();
            for (int i = 0;i < testData.Length-1;i++)
            {
                lineParser.Parse(testData[i]);
            }
            Bodies = lineParser.requestData;
            
            Assert.Equal(Bodies, BodiesControl);
            
        }
        [Fact]
        void TestComments()
        {
            for (int i = 0; i < testData.Length - 1; i++)
            {
                if (i < 2)
                    CommentsControl.Add(testData[i]);
                else
                    BodiesControl.Add(testData[i]);
            }
            LineParser lineParser = new LineParser();
            for (int i = 0; i < testData.Length - 1; i++)
            {
                lineParser.Parse(testData[i]);
            }
            Comments = lineParser.comments;
            Assert.Equal(Comments, CommentsControl);
        }
    }
}
