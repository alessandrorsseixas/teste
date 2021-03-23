using SiteMercado.Domain.SeedWorks.Classes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteMercado.Domain.SeedWorks.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByCode(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task<bool> Exist(TEntity entity);
        Task Delete(TEntity entity);
        Task<int> SaveChanges();
    }
}
