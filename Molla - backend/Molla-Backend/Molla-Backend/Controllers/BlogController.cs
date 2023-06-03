using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Molla_Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Models;
using Molla_Backend.ViewModels;
using Molla_Backend.Services.Interfaces;

namespace Molla_Backend.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _blogService.GetAllAsync();

            BlogVM model = new()
            {
                Blogs = blogs
            };

            return View(model);
        }
    }
}

