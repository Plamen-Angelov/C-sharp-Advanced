using System;
using System.IO;
using System.Threading.Tasks;

namespace _6._Folder_Size
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] fileNames = Directory.GetFiles("TestFolder");
            long totalSize = 0;

            foreach (var file in fileNames)
            {
                FileInfo info = new FileInfo(file);
                totalSize += info.Length;
            }

            double totalSizeInMB = (double)totalSize / 1024 / 1024;
            Console.Write(totalSizeInMB);
        }
    }
}
