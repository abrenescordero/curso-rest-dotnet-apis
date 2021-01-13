using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;

namespace Repositories
{
    // ORM => Object Relational Mapping
    public class ProductRepository
    {
        private readonly AdventureWorksDbContext _context;

        public ProductRepository(AdventureWorksDbContext context)
        {
            _context = context;
        }

        public Product[] Get() 
        {
            return _context.Products.ToArray();
        }

        public Product Add(Product value)
        {
            _context.Products.Add(value);

            _context.SaveChanges();

            return value;
        }

        public void Delete(int id)
        {
            var match = _context.Products.Find(id);

            if (match != null)
            {
                _context.Remove(match);
            }

            _context.SaveChanges();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }
    }
}