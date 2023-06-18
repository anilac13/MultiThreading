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
            },
            () =>
            {
                Console.WriteLine("Begin second task");
                GetMostCommonWords(words);
            },
            () =>
            {
                Console.WriteLine("Begin third task");
                GetCountForWord(words, "sleep");
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
        public void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into c
                                 orderby c.Count() descending
                                 select c.Key;
            var commonWords = frequencyOrder.Take(10);
            StringBuilder s = new StringBuilder();
            s.Append("Task 2 --> Most common words are: ");
            foreach ( var word in commonWords )
            {
                s.AppendLine($" {word}");
            }
            Console.WriteLine(s.ToString());
        }
        public void GetCountForWord(string[] words, string term)
        {
            var findWord = (from word in words
                            where word.ToUpper().Contains(term.ToUpper())
                            select word);
            Console.WriteLine($@"Task 3 --> The word ""{term}"" occurs {findWord.Count()} times");
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
