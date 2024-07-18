namespace WebScrape.Data.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get(CancellationToken cancellationToken = default);
        Task<T> Get(T item, CancellationToken cancellationToken = default);
        Task<T> GetByID(int Id, CancellationToken cancellationToken = default);
        Task Insert(T search, CancellationToken cancellationToken = default);
        Task Save(CancellationToken cancellationToken = default);
    }
}
