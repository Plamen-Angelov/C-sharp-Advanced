using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EX__1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                string line = reader.ReadLine();
                int currentLine = 0;

                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        if (currentLine % 2 == 0)
                        {
                            string newString = ReplaceSymbols(line);
                            string reversed = ReverseString(newString);
                            writer.WriteLine(reversed);
                        }

                        currentLine++;
                        line = reader.ReadLine();
                    }
                }
            }
        }

        private static string ReverseString(string newString)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = newString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                sb.Append($"{words[words.Length - 1 - i]} ");
            }

            return sb.ToString();
        }

        private static string ReplaceSymbols(string line)
        {
            char[] symbols = new char[] {'-', ',', '.', '!', '?'};

            foreach (var ch in line)
            {
                if (symbols.Contains(ch))
                {
                    line = line.Replace(ch, '@');
                }
            }
            return line;
        }
    }
}
