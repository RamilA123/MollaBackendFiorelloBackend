using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Areas.Admin.ViewModels.Blog;
using Molla_Backend.Areas.Admin.ViewModels.Icon;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IconController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILayoutService _layoutService;

        public IconController(AppDbContext context, ILayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index()
        {
            List<IconVM> iconsList = new();
            List<Icons> icons = await _context.Icons.Where(m=>!m.SoftDelete).ToListAsync();

            foreach (Icons eachIcon in icons)
            {
                IconVM model = new()
                {
                    Id = eachIcon.Id,
                    ClassName = eachIcon.ClassName,
                    Title = eachIcon.Title,
                    Info = eachIcon.Info,
                    Status = eachIcon.Status,
                    CreateDate = eachIcon.CreatedDate.ToString("dd-MM-yyyy")
                };

                iconsList.Add(model);
            }
            return View(iconsList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            Icons dbIcon = await _context.Icons.FirstOrDefaultAsync(m => m.Id == id);

            //if (dbBlog is null) return NotFound();

            IconDetailVM model = new()
            {
                ClassName = dbIcon.ClassName,
                Title = dbIcon.Title,
                Info = dbIcon.Info,
                Status = dbIcon.Status,
                CreateDate = dbIcon.CreatedDate.ToString("dd-MM-yyyy")
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest();

            Icons dbIcon = await _context.Icons.FirstOrDefaultAsync(m => m.Id == id);

            //if (dbIcon is null) return NotFound();

            dbIcon.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }
    }
}

