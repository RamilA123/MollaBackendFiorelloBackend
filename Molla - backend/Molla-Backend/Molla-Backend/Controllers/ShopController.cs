using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

namespace Molla_Backend.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productService.GetAllAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<ActionResult> GetText(string searchText)
        {
            //IEnumerable<Product> products = await _productService.GetAllAsync();
            //IEnumerable<Product> filteredProducts = products.Where(m => m.Features.Contains(searchText.ToString()));

            ViewBag.SearchText = searchText;

            return RedirectToAction("Index", "Shop");
        }
    }
}

