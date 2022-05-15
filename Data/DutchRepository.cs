using System;
using System.Collections.Generic;
using DutchTreat.Data.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly IDutchContext _ctx;

        public DutchRepository(IDutchContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = _ctx.GetCollection<Product>("Products");

            var results = await products.Find(_ => true).ToListAsync();

            return results;
        }

        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            var products = _ctx.GetCollection<Product>("Products");

            var results = await products.Find(p => p.Category == category).ToListAsync();

            return results;
        }
    }
}

