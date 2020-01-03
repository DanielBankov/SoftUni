namespace IteratorsAndComparators
{
    using System.Collections.Generic;

    public class Book
    {
        private string title;
        private int year;
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public IReadOnlyList<string> Authors { get; set; }
    }
}
