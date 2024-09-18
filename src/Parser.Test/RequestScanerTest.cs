namespace Parser.Test;

public class RequestScanerTest
{
    [Fact]
    void TestScanner()
    {
        var path = new DirectoryInfo("./examples");
        System.Console.WriteLine(path.FullName);
        var scaner = new RequestScaner(path);
        var files = scaner.Scan();
        FileInfo[] controlData =
        [
            new FileInfo("./examples/v1/some.http"),
            new FileInfo("./examples/v2/another.http"),
            new FileInfo("./examples/v2/some.http")
        ];
        files.Should().NotBeEmpty();
        var filesAsStrings = files.Select(f => f.FullName);
        foreach (var c in controlData)
        {
            filesAsStrings.Should().Contain(c.FullName);
        }
    }
}
