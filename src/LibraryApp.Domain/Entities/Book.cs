using LibraryApp.Domain.ValueObjects;

namespace LibraryApp.Domain.Entities;

public sealed class Book
{
    public Guid Id { get; set; }
    public BookHeader Header { get; set; } = null!;
    public Author? Author { get; set; }
    public DateTime PublicationDate { get; set; }

    public Book(Guid id, BookHeader header, DateTime publicationDate, Author? author = null)
    {
        Id = id;
        Header = header;
        Author = author;
        PublicationDate = publicationDate;
    }
    
    // Required by EntityFramework Core
    private Book() { }
}