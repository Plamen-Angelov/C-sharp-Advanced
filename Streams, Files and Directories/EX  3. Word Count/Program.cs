using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EX__3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("words.txt");
            string [] text = File.ReadAllLines("text.txt");
            Dictionary<string, int> countOfRepeate = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                countOfRepeate.Add(words[i], 0);
            }

            foreach (var line in text)
            {
                string[] wordsFromText = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.TrimStart(new char[] { '-', ',', '.', '!', '?'}))
                    .Select(x => x.TrimEnd(new char[] { '-', ',', '.', '!', '?'}))
                    .Select(x => x.ToLower())
                    .ToArray();

                foreach (var word in wordsFromText)
                {
                    if (countOfRepeate.ContainsKey(word))
                    {
                        countOfRepeate[word]++;
                    }
                }
            }
            

            string[] actualResult = new string[countOfRepeate.Count];
            int count = 0;

            foreach (var kvp in countOfRepeate)
            {
                actualResult[count] = $"{kvp.Key} - {kvp.Value}";
                count++;
            }

            File.WriteAllLines("actualResult.txt", actualResult);


            string[] expectedResult = new string[countOfRepeate.Count];
            int countOfOrdered = 0;

            foreach (var kvp2 in countOfRepeate.OrderByDescending(x => x.Value))
            {
                expectedResult[countOfOrdered] = $"{kvp2.Key} - {kvp2.Value}";
                countOfOrdered++;
            }
            File.WriteAllLines("expectedResult.txt", expectedResult);
        }
    }
}
