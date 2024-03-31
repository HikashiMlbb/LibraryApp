using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Shared;

namespace LibraryApp.Application.Interfaces;

public interface IAuthorsRepository
{
    public Result Add(Author author);
    public Result<IEnumerable<Author>> GetAll();
    public Result<Author> GetById(Guid id);
    public Result<Author> GetByName(string name);
    public Result<Author> GetByBookId(Guid id);
    public Result Update(Author author);
    public Result Delete(Author author);
    public Result IsNameUnique(string name);
}