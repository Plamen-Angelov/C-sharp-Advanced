using System;
using System.IO;

namespace EX__4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("copyMe.png", FileMode.Open))
            {
                using (FileStream writer = new FileStream("picture.png", FileMode.Create))
                {
                    while (reader.CanRead)
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0 , readBytes);
                    }
                }
            }
        }
    }
}
