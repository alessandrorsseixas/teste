using SiteMercado.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiteMercado.Domain.SeedWorks.Interfaces.Services
{
    public interface IProductService
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        Task<bool> Exist(Product product);
        Task<IEnumerable<Product>> Get(Expression<Func<Product, bool>> predicate);
        Task<Product> GetByCode(Expression<Func<Product, bool>> predicate);
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
    }
}
