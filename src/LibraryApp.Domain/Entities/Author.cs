namespace LibraryApp.Domain.Entities;

public sealed class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; }
    public DateTime BirthDay { get; set; }

    public Author(Guid id, string name, DateTime birthDay, ICollection<Book>? books = null)
    {
        Id = id;
        Name = name;
        Books = books ?? new List<Book>();
        BirthDay = birthDay;
    }

    // Required by EntityFramework Core
    private Author() { }
}