using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Persistence.Repositories;

public class AuthorsRepository(LibraryDatabaseContext db) : IAuthorsRepository
{
    public void Add(Author author)
    {
        db.Authors.Add(author);
    }

    public async Task<IEnumerable<Author>> GetAllAsync(CancellationToken token = default)
    {
        return await db.Authors
            .AsNoTracking()
            .Include(x => x.Books)
            .ToListAsync(token);
    }

    public async Task<Author?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await db.Authors
            .AsNoTracking()
            .Include(x => x.Books)
            .SingleOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<Author?> GetByNameAsync(string name, CancellationToken token = default)
    {
        return await db.Authors
            .AsNoTracking()
            .Include(x => x.Books)
            .SingleOrDefaultAsync(x => x.Name == name, token);
    }

    public async Task<Author?> GetByBookIdAsync(Guid id, CancellationToken token = default)
    {
        return await db.Authors
            .AsNoTracking()
            .Include(x => x.Books.Where(y => y.Id == id))
            .SingleOrDefaultAsync(x => x.Books.Any(y => y.Id == id), token);
    }

    public void Update(Author author)
    {
        var foundAuthor = db.Authors.Include(x => x.Books).SingleOrDefault(x => x.Id == author.Id);

        if (foundAuthor is null)
        {
            return;
        }

        foundAuthor.Name = author.Name;
        foundAuthor.BirthDay = author.BirthDay;
        foundAuthor.Books = author.Books;
    }

    public void Delete(Author author)
    {
        var foundAuthor = db.Authors.Include(x => x.Books).SingleOrDefault(x => x.Id == author.Id);

        if (foundAuthor is null)
        {
            return;
        }
        
        foundAuthor.Books.Clear();

        db.Authors.Remove(foundAuthor);
    }

    public bool IsNameUnique(string name)
    {
        return GetByNameAsync(name).GetAwaiter().GetResult() == null;
    }
}