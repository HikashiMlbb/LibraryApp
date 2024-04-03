using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Common.Interfaces;

public interface IAuthorsRepository
{
    public void Add(Author author);
    public Task<IEnumerable<Author>> GetAllAsync(CancellationToken token = default);
    public Task<Author?> GetByIdAsync(Guid id, CancellationToken token = default);
    public Task<Author?> GetByNameAsync(string name, CancellationToken token = default);
    public Task<Author?> GetByBookIdAsync(Guid id, CancellationToken token = default);
    public void Update(Author author);
    public void Delete(Author author);
    public bool IsNameUnique(string name);
}