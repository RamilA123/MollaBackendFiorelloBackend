using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Areas.Admin.ViewModels.Blog;
using Molla_Backend.Areas.Admin.ViewModels.WhoWeAre;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WhoWeAreController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILayoutService _layoutService;

        public WhoWeAreController(AppDbContext context, ILayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService; 
        }

        public async Task<IActionResult> Index()
        {
            WhoWeAreInfo whoWeAre = await _context.WhoWeAreInfo.Where(m => !m.SoftDelete).FirstOrDefaultAsync();
            IEnumerable<WhoWeAreImage> whoWeAreImage = await _context.WhoWeAreImage.ToListAsync();

            WhoWeAreVM model = new()
            {
                Id = whoWeAre.Id,
                Title = whoWeAre.Title,
                Info = whoWeAre.Info,
                MainDescription = whoWeAre.MainDescription,
                UpperImage = whoWeAreImage.FirstOrDefault().Image,
                BackImage = whoWeAreImage.LastOrDefault().Image,
                Status = whoWeAre.Status,
                CreateDate = whoWeAre.CreatedDate.ToString("dd-MM-yyyy")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            WhoWeAreInfo dbWhoWeAre = await _context.WhoWeAreInfo.FirstOrDefaultAsync(m => m.Id == id);
            WhoWeAreImage dbwhoWeAreImage = await _context.WhoWeAreImage.FirstOrDefaultAsync(m => m.Id == id);

            //if (dbBlog is null) return NotFound();

            WhoWeAreDetailVM model = new()
            {
                Title = dbWhoWeAre.Title,
                Info = dbWhoWeAre.Info,
                MainDescription = dbWhoWeAre.MainDescription,
                UpperImage = dbwhoWeAreImage.Image,
                BackImage = dbwhoWeAreImage.Image,
                Status = dbWhoWeAre.Status,
                CreateDate = dbWhoWeAre.CreatedDate.ToString("dd-MM-yyyy")
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest();

            Blog dbWhoWeAre = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            WhoWeAreImage dbwhoWeAreImage = await _context.WhoWeAreImage.FirstOrDefaultAsync(m => m.Id == id);

            //if (dbIcon is null) return NotFound();

            dbWhoWeAre.SoftDelete = true;
            dbwhoWeAreImage.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }
    }
}

