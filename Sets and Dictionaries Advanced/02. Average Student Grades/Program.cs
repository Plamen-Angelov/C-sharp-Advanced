using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (students.ContainsKey(student[0]) == false)
                {
                    students.Add(student[0], new List<decimal>());
                }

                students[student[0]].Add(decimal.Parse(student[1]));
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(v => v.ToString("F2")))}" +
                                  $" (avg: {student.Value.Average():F2})");
            }
        }
    }
}
