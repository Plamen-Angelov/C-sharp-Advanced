using System;
using System.IO.Compression;

namespace EX__6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\Teddy Beer\Магазин\снимки\1st B - Day",
                @"C:\Users\user\Desktop\test\archive.zip");
            ZipFile.ExtractToDirectory(@"C:\Users\user\Desktop\test\archive.zip",
                @"C:\Users\user\Desktop\test");
        }
    }
}
