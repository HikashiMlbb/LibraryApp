namespace LibraryApp.Application.Interfaces;

public interface IUnitOfWork
{
    public IAuthorsRepository Authors { get; set; }
    public IBooksRepository Books { get; set; }

    public int Complete();
    public Task<int> CompleteAsync(CancellationToken token);

    public void BeginTransaction();
    public void CommitTransaction();
    public void CancelTransaction();
}