using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Parser
{
    public class StringContent
    {
        private string _request;
        public StringContent(string Request)
        {
            _request = Request;
        }

        public List<string[]> HTTPRequests = new List<string[]>(); 
        
        public void RequestParse()
        {
            if (string.IsNullOrEmpty(_request)) return;
            string[] Lines = _request.Split(new char[] { '\n' });
            int count = 0;
            for (int i = count; i < Lines.Length-1; count++)
            {
                RequestAdd(Lines, count);
            }
        }
        private void RequestAdd(string[] Lines, int count)
        {
            string Comments ="";
            string Body="";
            string[] Arr = new string[2];
            string[] localLicnes = new string[Lines.Length-count-1];
            for (int i = count; i < localLicnes.Length-1; i++)
            {
                localLicnes[i] = Lines[i];
            }
            foreach (string Line in localLicnes)
            {
                if (!string.IsNullOrEmpty(Line))
                {
                    string[] RequestBody = Line.Split(new char[] { '#' });
                    if (!string.IsNullOrEmpty(RequestBody[0]))
                    {
                        Body += RequestBody[0] + "\n";
                        if (!string.IsNullOrEmpty(RequestBody[1]))
                            Comments += RequestBody[1] + "\n";
                    }
                    if (Line == "###")
                    {
                        Comments += Line;
                        Arr[0] =  Body;
                        Arr[1] = Comments;
                        break;
                    }
                }
                count++;
            }
           HTTPRequests.Add(Arr);
        }
    }
}
