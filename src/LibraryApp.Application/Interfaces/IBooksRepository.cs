using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;

namespace LibraryApp.Application.Interfaces;

public interface IBooksRepository
{
    public Result Add(Book book);
    public Result<IEnumerable<Book>> GetAll();
    public Result<Book> GetById(Guid id);
    public Result<Book> GetByTitle(string header);
    public Result<IEnumerable<Book>> GetByAuthorId(Guid id);
    public Result Update(Book book);
    public Result Delete(Book book);
}