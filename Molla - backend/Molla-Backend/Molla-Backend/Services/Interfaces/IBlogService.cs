using System;
using Molla_Backend.Models;

namespace Molla_Backend.Services.Interfaces
{
	public interface IBlogService
	{
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog> GetBlogByIdAsync(int? id);
    }
}

