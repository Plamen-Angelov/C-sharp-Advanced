using System;
using System.IO;
using System.Threading.Tasks;

namespace _1._Odd_Lines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //string[] lines = await File.ReadAllLinesAsync("TextFile.txt");
            //
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    if (i % 2 == 1)
            //    {
            //        await File.WriteAllTextAsync("output.txt", lines[i]);
            //    }
            //}

            using (StreamReader reader = new StreamReader("TextFile.txt"))
            {
                string line = await reader.ReadLineAsync();
                int currentLine = 0;
            
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        if (currentLine % 2 == 1)
                        {
                            Console.WriteLine(line);
            
                            await writer.WriteLineAsync(line);
                        }
            
                        currentLine++;
            
                        line = await reader.ReadLineAsync();
                    }
                }
            }
        }
    }
}
