using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3._Word_Count
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string wordsInLine = await File.ReadAllTextAsync("words.txt");
            string[] words = wordsInLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            Dictionary<string, int> repeatsOfWords = new Dictionary<string, int>();

            Regex regex = new Regex(@"[A-Za-z]+");
            MatchCollection matches = regex.Matches(await File.ReadAllTextAsync("text.txt"));

            
            foreach (var word in words)
            {
                repeatsOfWords.Add(word, 0);

                foreach (var match in matches)
                {
                    if (word == match.ToString().ToLower())
                    {
                        repeatsOfWords[word]++;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (var item in repeatsOfWords.OrderByDescending(x => x.Value))
                {
                    await writer.WriteLineAsync($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
