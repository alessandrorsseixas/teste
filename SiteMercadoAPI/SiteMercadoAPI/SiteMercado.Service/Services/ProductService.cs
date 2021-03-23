using SiteMercado.Domain.Model;
using SiteMercado.Domain.SeedWorks.Interfaces.Repositories;
using SiteMercado.Domain.SeedWorks.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SiteMercado.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Add(Product product)
        {
            try
            {
                return _productRepository.Add(product);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public Task Update(Product product)
        {
            try
            {
                return _productRepository.Update(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  Task Delete(Product product)
        {
            try
            {
                return  _productRepository.Delete(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Exist(Product product)
        {
            try
            {
                return await _productRepository.Exist(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Product>> Get(Expression<Func<Product, bool>> predicate)
        {
            try
            {
                return await _productRepository.Get(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await _productRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetByCode(Expression<Func<Product, bool>> predicate)
        {
            try
            {
                return await _productRepository.GetByCode(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _productRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
