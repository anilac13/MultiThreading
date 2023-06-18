using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class TPLOperation
    {
        public void TaskParallel()
        {
            string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");

        }

        private string[] CreateWordArray(string url)
        {
            Console.WriteLine($"Retrieving from url: {url}");
            string result = new WebClient().DownloadString(url);
            return result.Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '/', '\u000A' },
            StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
