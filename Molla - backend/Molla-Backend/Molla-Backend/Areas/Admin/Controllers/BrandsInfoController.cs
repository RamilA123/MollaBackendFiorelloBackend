using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Data;
using Molla_Backend.Areas.Admin.ViewModels.BrandsInfo;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;
using Molla_Backend.Areas.Admin.ViewModels.WhoWeAre;
using Molla_Backend.Areas.Admin.ViewModels.Blog;
using Molla_Backend.Areas.Admin.ViewModels.BrandsImage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsInfoController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly ILayoutService _layoutService;

        public BrandsInfoController(IBrandService brandService, ILayoutService layoutService)
        {
            _brandService = brandService;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index()
        {
            List<BrandsInfoVM> brandsInfoList = new();
            IEnumerable<BrandsInfo> brandsInfo = await _brandService.GetAllBrandsInfosAsync();

            foreach (BrandsInfo eachInfo in brandsInfo)
            {
                BrandsInfoVM model = new()
                {
                    Id = eachInfo.Id,
                    Title = eachInfo.Title,
                    Description = eachInfo.Description,
                    Status = eachInfo.Status,
                    CreateDate = eachInfo.CreatedDate.ToString("dd-MM-yyyy")
                };

                brandsInfoList.Add(model);
            }
            return View(brandsInfoList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            BrandsInfo dbBrandsInfo = await _brandService.GetBrandsInfoByIdAsync(id);

            //if (dbBlog is null) return NotFound();

            BrandsInfoDetailVM model = new()
            {
                Title = dbBrandsInfo.Title,
                Description = dbBrandsInfo.Description,
                Status = dbBrandsInfo.Status,
                CreateDate = dbBrandsInfo.CreatedDate.ToString("dd-MM-yyyy")
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest();

            BrandsInfo dbBrandsInfo = await _brandService.GetBrandsInfoByIdAsync(id);

            //if (dbIcon is null) return NotFound();

            dbBrandsInfo.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }
    }
}

