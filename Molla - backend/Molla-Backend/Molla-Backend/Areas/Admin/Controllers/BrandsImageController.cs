using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Molla_Backend.Areas.Admin.ViewModels.BrandsInfo;
using Molla_Backend.Areas.Admin.ViewModels.BrandsImage;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Areas.Admin.ViewModels.Blog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsImageController : Controller
    {
        private readonly ILayoutService _layoutService;
        private readonly IBrandService _brandService;

        public BrandsImageController(ILayoutService layoutService, IBrandService brandService)
        {
            _layoutService = layoutService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            List<BrandsImageVM> brandsImageList = new();
            IEnumerable<BrandsImage> brandsImage = await _brandService.GetAllBrandsImageAsync();

            foreach (BrandsImage eachImage in brandsImage)
            {
                BrandsImageVM model = new()
                {
                    Id = eachImage.Id,
                    Image = eachImage.Image,
                    Status = eachImage.Status,
                    CreateDate = eachImage.CreatedDate.ToString("dd-MM-yyyy")
                };

                brandsImageList.Add(model);
            }
            return View(brandsImageList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            BrandsImage dbBrands = await _brandService.GetBrandsImageByIdAsync(id);

            //if (dbBlog is null) return NotFound();

            BrandsImageDetailVM model = new()
            {
                Image = dbBrands.Image,
                CreateDate = dbBrands.CreatedDate.ToString("dd-MM-yyyy"),
                Status = dbBrands.Status,
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest();

            BrandsImage dbBrands = await _brandService.GetBrandsImageByIdAsync(id);

            //if (dbIcon is null) return NotFound();

            dbBrands.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }
    }
}

