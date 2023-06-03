using System;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

namespace Molla_Backend.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.Include(m => m.Images).Include(m => m.BlogAuthor).Where(m => !m.SoftDelete).ToListAsync();
        }

        public Task<Blog> GetBlogByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

