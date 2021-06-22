using System;
using System.IO;

namespace EX__2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                int countOfLetters = LetterCounter(lines[i]);
                int countOfPunctuationMarks = CountOfPunctuation(lines[i]);

                lines[i] = $"Line {i+1}: {lines[i]} ({countOfLetters})({countOfPunctuationMarks})";
            }

            File.WriteAllLines("output.txt", lines);
        }

        private static int CountOfPunctuation(string line)
        {
            int countOfPunctuation = 0;

            foreach (var ch in line)
            {
                if (char.IsPunctuation(ch))
                {
                    countOfPunctuation++;
                }
            }

            return countOfPunctuation;
        }


        private static int LetterCounter(string line)
        {
            int countOfLetters = 0;

            foreach (var ch in line)
            {
                if (char.IsLetter(ch))
                {
                    countOfLetters++;
                }
            }

            return countOfLetters;
        }
    }
}
