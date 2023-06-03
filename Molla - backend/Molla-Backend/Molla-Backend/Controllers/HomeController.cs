using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;
using Molla_Backend.ViewModels;

namespace Molla_Backend.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly IProductService _productService;
    private readonly IBrandService _brandService;

    public HomeController(AppDbContext context, IProductService productService, IBrandService brandService)
    {
        _context = context;
        _productService = productService;
        _brandService = brandService;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Slider> sliders = await _context.Sliders.Include(m => m.SliderImages).Where(m => !m.SoftDelete).ToListAsync();
        IEnumerable<BrandsImage> brandsImages = await _brandService.GetAllBrandsImageAsync();
        IEnumerable<Icons> icons = await _context.Icons.Where(m => !m.SoftDelete).ToListAsync();
        IEnumerable<Product> products = await _productService.GetAllAsync();

        HomeVM model = new()
        {
            Sliders = sliders,
            BrandsImages = brandsImages,
            Icons = icons,
            Products = products
        };

        return View(model);
    }
}

