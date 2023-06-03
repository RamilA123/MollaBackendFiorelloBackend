using System;
using Molla_Backend.Models;

namespace Molla_Backend.Services.Interfaces
{
	public interface IProductService
	{
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductByIdAsync(int? id);
        Task<IEnumerable<Product>> GetAllTrendingProduct();
        Task<Product> GetAllTrendingProductsById(int? id);
        Task<IEnumerable<Product>> GetAllTopSellingProduct();
        Task<Product> GetAllTopSellingProductsById(int? id);
    }
}

