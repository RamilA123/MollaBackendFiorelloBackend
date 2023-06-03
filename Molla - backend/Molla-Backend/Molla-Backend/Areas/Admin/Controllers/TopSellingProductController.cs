using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Areas.Admin.ViewModels.Blog;
using Molla_Backend.Areas.Admin.ViewModels.Product;
using Molla_Backend.Areas.Admin.ViewModels.TopSellingProduct;
using Molla_Backend.Areas.Admin.ViewModels.TrendingProduct;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TopSellingProductController : Controller
    {
        private readonly ILayoutService _layoutService;
        private readonly IProductService _productService;

        public TopSellingProductController(ILayoutService layoutService, IProductService productService)
        {
            _layoutService = layoutService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<TopSellingProductVM> productList = new();
            IEnumerable<Product> products = await _productService.GetAllTopSellingProduct();

            foreach (Product eachTopSellingProduct in products)
            {
                TopSellingProductVM model = new()
                {
                    Id = eachTopSellingProduct.Id,
                    Image = eachTopSellingProduct.Images.FirstOrDefault().Image,
                    Name = eachTopSellingProduct.Name,
                    Features = eachTopSellingProduct.Features,
                    Price = eachTopSellingProduct.Price,
                    Rating = eachTopSellingProduct.Rating,
                    SalesCount = eachTopSellingProduct.SalesCount,
                    Status = eachTopSellingProduct.Status,
                    CreateDate = eachTopSellingProduct.CreatedDate.ToString("dd-MM-yyyy")
                };

                productList.Add(model);
            }
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            Product dbProduct = await _productService.GetAllTopSellingProductsById(id);

            //if (dbBlog is null) return NotFound();

            TopSellingProductDetailVM model = new()
            {
                Image = dbProduct.Images.FirstOrDefault().Image,
                Name = dbProduct.Name,
                Features = dbProduct.Features,
                Price = dbProduct.Price,
                Rating = dbProduct.Rating,
                SalesCount = dbProduct.SalesCount,
                Status = dbProduct.Status,
                CreateDate = dbProduct.CreatedDate.ToString("dd-MM-yyyy")
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest();

            Product dbProduct = await _productService.GetAllTopSellingProductsById(id);

            //if (dbIcon is null) return NotFound();

            dbProduct.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }
    }
}

