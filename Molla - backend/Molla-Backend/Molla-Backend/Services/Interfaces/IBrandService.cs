using System;
using Molla_Backend.Models;

namespace Molla_Backend.Services.Interfaces
{
	public interface IBrandService
	{
        Task<BrandsInfo> GetBrandsInfoAsync();
        Task<BrandsInfo> GetBrandsInfoByIdAsync(int? id);
        Task<IEnumerable<BrandsInfo>> GetAllBrandsInfosAsync();
        Task<IEnumerable<BrandsImage>> GetAllBrandsImageAsync();
        Task<BrandsImage> GetBrandsImageByIdAsync(int? id);
    }
}

