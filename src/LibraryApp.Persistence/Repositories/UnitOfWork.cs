using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Infrastructure.Data;

namespace LibraryApp.Persistence.Repositories;

public class UnitOfWork(LibraryDatabaseContext db) : IUnitOfWork
{
    public IAuthorsRepository Authors { get; set; } = new AuthorsRepository(db);
    public IBooksRepository Books { get; set; } = new BooksRepository(db);
    
    public int Complete()
    {
        return db.SaveChanges();
    }

    public async Task<int> CompleteAsync(CancellationToken token = default)
    {
        return await Task.Run(Complete, token);
    }

    public void BeginTransaction()
    {
        db.Database.BeginTransaction();
    }

    public void ApplyTransaction()
    {
        db.Database.CommitTransaction();
    }

    public void CancelTransaction()
    {
        db.Database.RollbackTransaction();
    }
}