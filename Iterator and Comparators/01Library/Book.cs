using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public IReadOnlyList<string> Autors { get; set; }

        public Book(string title, int year, params string [] autors)
        {
            Title = title;
            Year = year;
            Autors = autors;
        }

    }
}
