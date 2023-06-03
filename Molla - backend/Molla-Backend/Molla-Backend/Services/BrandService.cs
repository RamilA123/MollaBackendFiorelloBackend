using System;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

namespace Molla_Backend.Services
{
    public class BrandService : IBrandService
    {
        private readonly AppDbContext _context;

        public BrandService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrandsImage>> GetAllBrandsImageAsync()
        {
            return await _context.BrandsImages.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<BrandsInfo> GetBrandsInfoAsync()
        {
            return await _context.BrandsInfos.Where(m => !m.SoftDelete).FirstOrDefaultAsync();
        }

        public async Task<BrandsImage> GetBrandsImageByIdAsync(int? id)
        {
            return await _context.BrandsImages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<BrandsInfo> GetBrandsInfoByIdAsync(int? id)
        {
            return await _context.BrandsInfos.Where(m=>!m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<BrandsInfo>> GetAllBrandsInfosAsync()
        {
            return await _context.BrandsInfos.Where(m => !m.SoftDelete).ToListAsync();
        }
    }
}

