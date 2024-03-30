using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;
using LibraryApp.Domain.ValueObjects;

namespace LibraryApp.Application.Interfaces;

public interface IBooksRepository
{
    public Result Add(Book book);
    public Result<IEnumerable<Book>> GetAll();
    public Result<Book> GetById(Guid id);
    public Result<Book> GetByHeader(BookHeader header);
    public Result<IEnumerable<Book>> GetByAuthorId(Guid id);
    public Result Update(Book book);
    public Result Delete(Book book);
}