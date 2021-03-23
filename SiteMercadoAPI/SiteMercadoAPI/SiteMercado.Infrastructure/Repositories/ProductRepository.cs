using SiteMercado.Domain.Model;
using SiteMercado.Domain.SeedWorks.Interfaces.Repositories;
using SiteMercado.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteMercado.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
