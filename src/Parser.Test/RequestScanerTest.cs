using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Test
{
    public class RequestScanerTest
    {
        [Fact]
        void TestScanner()
        {
            string path = "E:\\ForesLov\\RESTClient\\examples\\";
            RequestScaner scaner = new RequestScaner(path);
            string[] files = scaner.Scan();
            string[] controlData = { "E:\\ForesLov\\RESTClient\\examples\\v1\\some.http", "E:\\ForesLov\\RESTClient\\examples\\v2\\another.http", "E:\\ForesLov\\RESTClient\\examples\\v2\\some.http" };

            Assert.Equal(controlData, files);
        }

    }
}
