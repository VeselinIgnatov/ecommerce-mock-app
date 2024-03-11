using Application.Interfaces;
using Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context, ILogger logger) 
            : base(context, logger)
        {
        }

        public IQueryable<Product> Search(string search)
        {
            return _context.Products.Where(x => x.Name.Contains(search)
                        || x.Description.Contains(search));
        }
    }
}
