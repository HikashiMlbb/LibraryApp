using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Persistence.Repositories;

public class BooksRepository(LibraryDatabaseContext db) : IBooksRepository
{
    public void Add(Book book)
    {
        db.Books.Add(book);
    }

    public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken token = default)
    {
        return await db.Books
            .AsNoTracking()
            .Include(x => x.Author)
            .ToListAsync(token);
    }

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await db.Books
            .AsNoTracking()
            .Include(x => x.Author)
            .SingleOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<Book?> GetByTitleAsync(string title, CancellationToken token = default)
    {
        return await db.Books
            .AsNoTracking()
            .Include(x => x.Header)
            .SingleOrDefaultAsync(x => x.Header.Title == title, token);
    }

    public async Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid id, CancellationToken token = default)
    {
        return await db.Books
            .AsNoTracking()
            .Include(x => x.Author)
            .Where(x => x.Author != null && x.Author.Id == id)
            .ToListAsync(token);
    }

    public async Task Update(Book book, CancellationToken token = default)
    {
        var foundBook = await db.Books.SingleOrDefaultAsync(x => x.Id == book.Id, cancellationToken: token);

        if (foundBook is null) return;

        foundBook.Header = book.Header;
        foundBook.Author = book.Author;
        foundBook.PublicationDate = book.PublicationDate;
    }

    public void Delete(Book book)
    {
        db.Books.Where(x => x.Id == book.Id).ExecuteDelete();
    }

    public bool IsTitleUnique(string title)
    {
        return GetByTitleAsync(title).GetAwaiter().GetResult() == null;
    }

    public void Attach(Book book)
    {
        db.Books.Attach(book);
    }

    public void Attach(IEnumerable<Book> books)
    {
        db.Books.AttachRange(books);
    }
}