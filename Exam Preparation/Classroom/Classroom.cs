using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> students = new List<Student>();

        public int Capacity { get ; set; }

        public int Count { get { return students.Count; } }

        public Classroom(int capacity)
        {
            Capacity = capacity;
        }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            foreach (var item in students)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    students.Remove(item);
                    return $"Dismissed student {firstName} {lastName}";
                }
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            bool areThereStudents = students.Any(s => s.Subject == subject);

            if (areThereStudents)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in students)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students
                .Where(s => s.FirstName == firstName && s.LastName == lastName)
                .FirstOrDefault();

            return student;
        }
    }
}
