using LibraryApp.Domain.Shared;

namespace LibraryApp.Application.Common.Errors;

public static class BookErrors
{
    public static readonly Error IdNotFound = new("Books.NotFound", "Book with given ID has not been found.");
    public static readonly Error TitleNotFound = new("Books.NotFound", "Book with given title has not been found.");
    public static readonly Error NotUnique = new("Book.NotUnique", "Book with given title already exists.");
}