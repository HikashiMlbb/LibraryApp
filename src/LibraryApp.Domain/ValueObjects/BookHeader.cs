namespace LibraryApp.Domain.ValueObjects;

public sealed class BookHeader
{
    public const int MaxTitleLength = 50;
    public const int MinTitleLength = 3;
    public const int MaxDescriptionLength = 2500;
    
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public BookHeader(string title, string? description = null)
    {
        Title = title;
        Description = description;
    }

    // Required by EntityFramework Core
    private BookHeader() { }
}