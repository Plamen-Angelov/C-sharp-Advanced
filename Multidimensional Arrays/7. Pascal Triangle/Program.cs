using System;


namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            long[][] triangel = new long[num][];

            for (int i = 0; i < num; i++)
            {
                long[] line = new long[i+1];
                line[0] = 1;
                line[line.Length - 1] = 1;

                for (int j = 1; j < line.Length-1; j++)
                {
                    line[j] = triangel[i - 1][j] + triangel[i - 1][j - 1];
                }

                triangel[i] = line;
            }

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(string.Join(' ', triangel[i]));
            }
        }
    }
}
