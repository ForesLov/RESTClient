namespace Backend.Test;

public class HistoryProviderTest
{
    [Fact]
    public void FileTest()
    {
        var provider = new HistoryProvider();
        provider.HistoryFile.Should().NotBeNull();
        provider.HistoryFile.Delete();
    }

    [Fact]
    public void HistoryAppendTest()
    {
        var provider = new HistoryProvider();
        provider.HistoryFile.Delete();

        var dir1Name = "my-examle/dir";
        var dir2Name = "my-examle2/dir/";
        var dir = new DirectoryInfo(dir1Name);
        var dir2 = new DirectoryInfo(dir2Name);
        provider.Append(dir);
        provider.Append(dir2);

        provider.HistoryFile.Exists.Should().BeTrue();

        var text = File.ReadLines(provider.HistoryFile.FullName);
        text.Should().NotBeNull().And.NotBeEmpty();

        text.Should().BeEquivalentTo([dir.FullName, dir2.FullName]);
    }

    [Fact]
    public void GetHistoryTest()
    {
        var provider = new HistoryProvider();
        provider.HistoryFile.Delete();

        var dir1Name = "my-examle/dir";
        var dir2Name = "my-examle2/dir/";
        var dir = new DirectoryInfo(dir1Name);
        var dir2 = new DirectoryInfo(dir2Name);
        provider.Append(dir);
        provider.Append(dir2);

        var last = provider.GetLast();
        last.Should().NotBeNull();
        last?.FullName.Should().BeEquivalentTo(dir2.FullName);
        provider
            .GetLast10()
            .Select(h => h.FullName)
            .Should()
            .BeEquivalentTo([dir.FullName, dir2.FullName]);
    }
}
