namespace RestClient.Parser;

public class RequestScaner
{
    private readonly DirectoryInfo _dir;
    public RequestScaner(DirectoryInfo dir)
    {
        _dir = dir;
    }

    public FileInfo[] Scan(int level = 2)
    {
        return (GetFiles(_dir, level - 1));
    }

    private FileInfo[] GetFiles(DirectoryInfo dir, int depth)
    {
        if (!dir.Exists)
            return [];

        var result = new List<FileInfo>();
        result.AddRange(dir.GetFiles("*.http", SearchOption.TopDirectoryOnly));

        if (depth > 0)
        {
            foreach (var subdir in dir.GetDirectories())
            {
                result.AddRange(GetFiles(subdir, depth - 1));
            }
        }
        return result.ToArray();

    }
}
