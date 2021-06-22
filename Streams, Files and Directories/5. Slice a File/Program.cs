using System;
using System.IO;
using System.Threading.Tasks;

namespace _5._Slice_a_File
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int parts = 4;
            int totalReadBytes = 0;

            using (FileStream reader = new FileStream("sliceMe.txt", FileMode.Open))
            {
                long partSize = reader.Length / 4;

                for (int i = 1; i <= parts; i++)
                {
                    byte[] buffer = new byte[500];
                    int readBytes = 0;

                    using (FileStream writer = new FileStream($"Part-{i}.txt", FileMode.Create))
                    {
                        while (readBytes < partSize && totalReadBytes < reader.Length)
                        {
                           int bytes =  await reader.ReadAsync(buffer, 0, buffer.Length);
                            await writer.WriteAsync(buffer, 0, buffer.Length);
                            readBytes += bytes;
                            totalReadBytes += bytes;
                        }
                    }
                }
            }
        }
    }
}
