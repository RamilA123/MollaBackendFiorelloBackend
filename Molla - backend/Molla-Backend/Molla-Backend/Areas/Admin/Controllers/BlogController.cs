using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Areas.Admin.ViewModels.Blog;
using Molla_Backend.Areas.Admin.ViewModels.CustomerImpression;
using Molla_Backend.Services.Interfaces;
using Molla_Backend.Data;
using Molla_Backend.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ILayoutService _layoutService;
        private readonly IBlogService _blogService;

        public BlogController(ILayoutService layoutService, IBlogService blogService)
        {
            _layoutService = layoutService;
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogVM> blogList = new();
            IEnumerable<Blog> blogs = await _blogService.GetAllAsync();

            foreach (Blog eachBlog in blogs)
            {
                BlogVM model = new()
                {
                    Id = eachBlog.Id,
                    Image = eachBlog.Images.FirstOrDefault().Image,
                    Title = eachBlog.Title,
                    Info = eachBlog.Info,
                    Author = eachBlog.BlogAuthor.FullName,
                    Status = eachBlog.Status,
                    CreateDate = eachBlog.CreatedDate.ToString("dd-MM-yyyy")
                };

                blogList.Add(model);
            }
            return View(blogList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            Blog dbBlog = await _blogService.GetBlogByIdAsync(id);

            //if (dbBlog is null) return NotFound();

            BlogDetailVM model = new()
            {
                Image = dbBlog.Images.FirstOrDefault().Image,
                Title = dbBlog.Title,
                Info = dbBlog.Info,
                Author = dbBlog.BlogAuthor.FullName,
                CreateDate = dbBlog.CreatedDate.ToString("dd-MM-yyyy"),
                Status = dbBlog.Status,
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest();

            Blog dbBlog = await _blogService.GetBlogByIdAsync(id);

            //if (dbIcon is null) return NotFound();

            dbBlog.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }

    }
}

