using LibraryApp.Domain.Shared;

namespace LibraryApp.Application.Common.Errors;

public static class AuthorErrors
{
    public static readonly Error NotUnique = new("Authors.NotUnique", "Author with given name already exists.");
    public static readonly Error IdNotFound = new("Authors.NotFound", "Author with given ID has not been found.");
    public static readonly Error NameNotFound = new("Authors.NotFound", "Author with given name has not been found.");
    public static readonly Error BookNotFound = new ("Authors.NotFound", "Author with given book has not been found.");
}