using System;
using System.IO;
using System.Threading.Tasks;

namespace _4._Merge_Files
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] first = await File.ReadAllLinesAsync("FileOne.txt");
            string[] second = await File.ReadAllLinesAsync("FileTwo.txt");
            string[] third = new string[first.Length + second.Length];
            int counter = 0;

            for (int i = 0; i < third.Length; i+=2)
            {
                third[i] = first[counter];
                third[i + 1] = second[counter];
                counter++;
            }

            await File.WriteAllLinesAsync("output.txt", third);
        }
    }
}
