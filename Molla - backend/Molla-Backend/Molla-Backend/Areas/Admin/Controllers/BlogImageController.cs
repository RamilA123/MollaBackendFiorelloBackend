using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Areas.Admin.ViewModels.BlogImage;
using Molla_Backend.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogImageController : Controller
    {
        private readonly ILayoutService _layoutService;
        private readonly IBlogService _blogService;

        public BlogImageController(ILayoutService layoutService, IBlogService blogService)
        {
            _layoutService = layoutService;
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            List<BlogImageVM> imageList = new(); 
            IEnumerable<Blog> blogs = await _blogService.GetAllAsync();

            foreach (Blog eachBlogImage in blogs)
            {
                BlogImageVM model = new()
                {
                    Id = eachBlogImage.Id,
                    Image = eachBlogImage.Images.FirstOrDefault().Image,
                    Status = eachBlogImage.Status,
                    CreateDate = eachBlogImage.CreatedDate.ToString("dd-MM-yyyy")
                };

                imageList.Add(model);
            }
            return View(imageList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            Blog dbBlog = await _blogService.GetBlogByIdAsync(id);

            //if (dbBlog is null) return NotFound();

            BlogImageDetailVM model = new()
            {
                Image = dbBlog.Images.FirstOrDefault().Image,
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

