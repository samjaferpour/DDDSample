namespace Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAllAsync();
    }
}
