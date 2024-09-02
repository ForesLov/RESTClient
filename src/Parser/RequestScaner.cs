using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Parser
{
    public class RequestScaner
    {
        string path;
        public RequestScaner(string Path) 
        {
            path = Path;
        }
        
        
        /*public void Scan(int level = 2)
        {
            if (Directory.Exists(path))
            {
                files = (string[])Directory.GetFiles(path, "*.http").Where(f => f.Split(new char[] { '/' }).Count() <= level + path.Split(new char[] { '/' }).Count());
            }
        }*/
        public string[] Scan(int level = 2)
        {
            List<string> files = new List<string>();
            if (Directory.Exists(path))
            {
                var localPath = Directory.GetDirectories(path).Where(x => x.Split('/').Count() <= level + path.Split('/').Count());
                foreach (var directory in localPath)
                {
                    files.AddRange( Directory.GetFiles(directory, "*.http", SearchOption.TopDirectoryOnly));
                }
                return files.ToArray();
            }
            return null;
        }
    }
}
