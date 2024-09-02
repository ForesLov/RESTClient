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
            var path = new DirectoryInfo("./examples");
            System.Console.WriteLine(path.FullName);
            RequestScaner scaner = new RequestScaner(path.FullName);
            var files = scaner.Scan();
            string[] controlData = [
                new FileInfo("./examples/v1/some.http").FullName,
                new FileInfo("./examples/v2/another.http").FullName,
                new FileInfo("./examples/v2/some.http").FullName ];

            Assert.Equal(controlData, files);
        }

    }
}
