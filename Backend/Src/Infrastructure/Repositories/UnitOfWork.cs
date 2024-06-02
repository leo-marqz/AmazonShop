
using System;
using System.Collections;
using System.Threading.Tasks;
using AmazonShop.Application.Persistence;
using AmazonShop.Infrastructure.Persistence;

namespace AmazonShop.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly AmazonShopDbContext _db;

        public UnitOfWork(AmazonShopDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<int> Completed(){
            return await _db.SaveChangesAsync();
        }
        

        public void Dispose()
        {
            _db.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if(_repositories is null){
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if(!_repositories.ContainsKey(type)){
                var repositoryType = typeof(RepositoryBase<>);
                var respositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _db);
                _repositories.Add(type, respositoryInstance);
            }

            return (IAsyncRepository<TEntity>) _repositories[type]!;
        }
    }
}