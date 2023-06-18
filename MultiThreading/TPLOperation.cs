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
            
            #region ParallelTask
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin first task");
                GetLongestWords(words);
            }
            );
            #endregion
        }

        public string GetLongestWords(string[] words)
        {
            var longestWord = (from word in words
                               orderby word.Length descending
                               select word).First();
            Console.WriteLine($"Task 1: --> Longest word is {longestWord}");
            return longestWord;
        }

        public string[] CreateWordArray(string url)
        {
            Console.WriteLine($"Retrieving from url: {url}");
            string result = new WebClient().DownloadString(url);
            return result.Split(new char[] { ' ', ',', '.', ';', ':', '-', '_', '/', '\u000A' },
            StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
