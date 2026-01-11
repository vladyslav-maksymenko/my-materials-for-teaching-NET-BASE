namespace Module12ConsoleApp;

// Клас для завдань модуля 12
public class Book
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int Pages { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, string genre, int pages, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Pages = pages;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} ({Genre}), {Pages} pages, {Year}";
    }
}


