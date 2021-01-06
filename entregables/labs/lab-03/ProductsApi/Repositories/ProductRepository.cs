﻿using Core.Data;
using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories

{
    public class ProductRepository

    {
        //ORM Object Relational Mapping
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
                _context.Products.Remove(match);
            }
            _context.SaveChanges();

        }

        public object Get(int id)
        {

            return _context.Products.Find(id);

        }
    }
}