using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Parser;

public class LineParser
{
    private readonly string _line;

    public LineParser(string Line)
    { 
        _line = Line;
    }
    Commentary commentary = new Commentary();
    RequestData requestData = new RequestData();
    public void Parse()
    {
        if (!string.IsNullOrEmpty(_line))
        {
            if (_line.StartsWith("#") || _line.StartsWith("//"))
            {
                IsCommentary(commentary, false);
            }
            if (_line.StartsWith("###"))
            {
                IsCommentary(commentary, true);
            }
            else
            {
                IsRequestData(requestData);
            }
        }
    }
    public Commentary IsCommentary(Commentary commentary, bool IsInterrupt)
    {
        commentary.CommentaryText.Add(_line, IsInterrupt);
        return commentary;
    }
    public RequestData IsRequestData(RequestData requestData)
    {
        requestData.RequestDataText.Add(_line);
        return requestData;
    }

    public class Commentary
    {
        public Dictionary<string, bool> CommentaryText;
    }
    public class RequestData
    {
        public List<string> RequestDataText;
    }
}
