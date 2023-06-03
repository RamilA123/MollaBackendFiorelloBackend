using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Molla_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Data;
using Molla_Backend.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IProductService _productService;

        public ProductDetailController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            Product product = await _productService.GetProductByIdAsync(id);
            return View(product);
        }
    }
}

