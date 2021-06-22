using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EX__5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<FileInfo>> filesByExtensions = new Dictionary<string, List<FileInfo>>();
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;

                if (!filesByExtensions.ContainsKey(extension))
                {
                    filesByExtensions.Add(extension, new List<FileInfo>());
                }

                filesByExtensions[extension].Add(info);
            }

            using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
            {
                foreach (var kvp in filesByExtensions
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key))
                {
                    writer.WriteLine($"{kvp.Key}:");

                    foreach (var info in kvp.Value.OrderBy(x => x.Length))
                    {
                        writer.WriteLine($"--{info.Name} - {info.Length / 1024}kb");
                    }
                }
            }
        }
    }
}
