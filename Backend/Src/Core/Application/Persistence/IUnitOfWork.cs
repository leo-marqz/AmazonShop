using System;
using System.Threading.Tasks;

namespace AmazonShop.Application.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> Completed();
    }
}