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

        // foreach (var f in controlData)
        // {
        //     Assert.Contains(f, files);
        // }
        //
        files.Should().NotBeEmpty();
        var filesAsStrings = files.Select(f => f.FullName);
        foreach (var c in controlData)
        {
            filesAsStrings.Should().Contain(c.FullName);
        }
        // Assert.Collection(files, el =>
        // {
        //     controlData.Contains(el);
        // });

        // Assert.Equal(controlData.Select(f => f.FullName), files.Select(f => f.FullName));
    }

}
