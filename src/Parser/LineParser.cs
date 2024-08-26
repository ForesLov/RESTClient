using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Parser;

public class LineParser
{
    private string Line;
    public List <string> comments = new List <string>();
    public List <string> requestData = new List <string>();
    public string requestInterrupt = "//Request interrupt!";
    public LineParser(string line) 
    { 
        Line = line;
    }
    
    public List<string> Parse(string Line)
    {
        if (!string.IsNullOrEmpty(Line))
        {
            if (Line.StartsWith("#") || Line.StartsWith("//"))
            {
                comments.Add(Line);
                return comments;
            }
            if (Line.StartsWith("###"))
            {
                comments.Add(Line + "\n" + requestInterrupt);
                return comments;
            }
            else
            { 
                requestData.Add(Line);
                return requestData;
            }
        }
        else
        {
            return null;
        }
    }
}
