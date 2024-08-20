using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Parser;

public class LineParser
{
    private string Line;
    public LineParser(string line) 
    { 
        Line = line;
    }
    public List <string> comments = new List <string>();
    public List <string> requestData = new List <string>();
    public string requestInterrupt = "";
    void Parse(string Line )
    {
        if (string.IsNullOrEmpty(Line))
        {
            if (Line.StartsWith("#") || Line.StartsWith("//"))
            {
                comments.Add(Line);
            }
            else if(Line.StartsWith("###")) 
            {
                requestInterrupt = Line;
            }
            else
            {
                requestData.Add(Line);
            }
        }
    }
}
