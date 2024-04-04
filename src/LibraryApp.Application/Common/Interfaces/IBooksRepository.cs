using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Common.Interfaces;

public interface IBooksRepository
{
    public void Add(Book book);
    public Task<IEnumerable<Book>> GetAllAsync(CancellationToken token = default);
    public Task<Book?> GetByIdAsync(Guid id, CancellationToken token = default);
    public Task<Book?> GetByTitleAsync(string title, CancellationToken token = default);
    public Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid id, CancellationToken token = default);
    public Task Update(Book book, CancellationToken token = default);
    public void Delete(Book book);
    public bool IsTitleUnique(string title);
    public void Attach(Book book);
    public void Attach(IEnumerable<Book> books);
}