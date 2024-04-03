namespace LibraryApp.Application.Common.Interfaces;

public interface IUnitOfWork
{
    public IAuthorsRepository Authors { get; set; }
    public IBooksRepository Books { get; set; }

    public int Complete();
    public Task<int> CompleteAsync(CancellationToken token = default);

    public void BeginTransaction();
    public void ApplyTransaction();
    public void CancelTransaction();
}