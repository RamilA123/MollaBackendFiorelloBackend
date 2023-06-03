using System;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;
namespace Molla_Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.Images).Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            return await _context.Products.Include(m => m.Images).Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllTrendingProduct()
        {
            return await _context.Products.Include(m => m.Images).Where(m => !m.SoftDelete && m.SalesCount >= 50).ToListAsync();
        }

        public async Task<Product> GetAllTrendingProductsById(int? id)
        {
            return await _context.Products.Include(m => m.Images).Where(m => !m.SoftDelete && m.SalesCount >= 50).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllTopSellingProduct()
        {
            return await _context.Products.Include(m => m.Images).Where(m => !m.SoftDelete && m.Rating >= 3).ToListAsync();
        }

        public async Task<Product> GetAllTopSellingProductsById(int? id)
        {
            return await _context.Products.Include(m => m.Images).Where(m => !m.SoftDelete && m.Rating >= 3).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}

