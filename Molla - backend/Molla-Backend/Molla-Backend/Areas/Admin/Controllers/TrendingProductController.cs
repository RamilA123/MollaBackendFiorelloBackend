using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Areas.Admin.ViewModels.TopSellingProduct;
using Molla_Backend.Areas.Admin.ViewModels.TrendingProduct;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrendingProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILayoutService _layoutService;

        public TrendingProductController(IProductService productService, ILayoutService layoutService)
        {
            _productService = productService;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index()
        {
            List<TrendingProductVM> productList = new();
            IEnumerable<Product> products = await _productService.GetAllTrendingProduct();

            foreach (Product eachTrendingProduct in products)
            {
                TrendingProductVM model = new()
                {
                    Id = eachTrendingProduct.Id,
                    Image = eachTrendingProduct.Images.FirstOrDefault().Image,
                    Name = eachTrendingProduct.Name,
                    Features = eachTrendingProduct.Features,
                    Price = eachTrendingProduct.Price,
                    Rating = eachTrendingProduct.Rating,
                    SalesCount = eachTrendingProduct.SalesCount,
                    Status = eachTrendingProduct.Status,
                    CreateDate = eachTrendingProduct.CreatedDate.ToString("dd-MM-yyyy")
                };

                productList.Add(model);
            }
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            Product dbProduct = await _productService.GetAllTrendingProductsById(id);

            //if (dbBlog is null) return NotFound();

            TrendingProductDetailVM model = new()
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

            Product dbProduct = await _productService.GetAllTrendingProductsById(id);

            //if (dbIcon is null) return NotFound();

            dbProduct.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }
    }
}

