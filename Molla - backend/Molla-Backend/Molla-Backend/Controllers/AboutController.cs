using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Molla_Backend.Models;
using Molla_Backend.ViewModels;
using Molla_Backend.Data;
using Molla_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Molla_Backend.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBrandService _brandService;

        public AboutController(AppDbContext context, IBrandService brandService)
        {
            _context = context;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            WhoWeAreInfo whoWeAre = await _context.WhoWeAreInfo.Where(m => !m.SoftDelete).FirstOrDefaultAsync();
            IEnumerable<WhoWeAreImage> whoWeAreImage = await _context.WhoWeAreImage.Where(m => !m.SoftDelete).ToListAsync();
            BrandsInfo brandsInfo = await _brandService.GetBrandsInfoAsync();
            IEnumerable<BrandsImage> brandsImages = await _brandService.GetAllBrandsImageAsync();
            IEnumerable<TeamMembers> teamMembers = await _context.TeamMembers.Include(m => m.Images).Where(m => !m.SoftDelete).ToListAsync();
            IEnumerable<CustomersComment> customersComments = await _context.CustomersComments.Where(m => !m.SoftDelete).ToListAsync();

            AboutVM model = new()
            {
                WhoWeAre = whoWeAre,
                WhoWeAreImage = whoWeAreImage,
                BrandsInfo = brandsInfo,
                BrandsImages = brandsImages,
                TeamMembers = teamMembers,
                CustomersComments = customersComments
            };

            return View(model);
        }
    }
}

