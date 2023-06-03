using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Areas.Admin.ViewModels.Blog;
using Molla_Backend.Areas.Admin.ViewModels.CustomerImpression;
using Molla_Backend.Areas.Admin.ViewModels.TeamMember;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerImpressionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILayoutService _layoutService;

        public CustomerImpressionController(AppDbContext context, ILayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index()
        {
            List<CustomerImpressionVM> customerList = new();
            List<CustomersComment> customersComments = await _context.CustomersComments.Where(m => !m.SoftDelete).ToListAsync();

            foreach (CustomersComment eachCustomer in customersComments)
            {
                CustomerImpressionVM model = new()
                {
                    Id = eachCustomer.Id,
                    Image = eachCustomer.Image,
                    FullName = eachCustomer.FullName,
                    Position = eachCustomer.Position,
                    Status = eachCustomer.Status,
                    CreateDate = eachCustomer.CreatedDate.ToString("dd-MM-yyyy")
                };

                customerList.Add(model);
            }
            return View(customerList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            CustomersComment dbCustomer = await _context.CustomersComments.FirstOrDefaultAsync(m => m.Id == id);

            //if (dbBlog is null) return NotFound();

            CustomerImpressionDetailVM model = new()
            {
                Image = dbCustomer.Image,
                FullName = dbCustomer.FullName,
                Position = dbCustomer.Position,
                Comments = dbCustomer.Description,
                Status = dbCustomer.Status,
                CreateDate = dbCustomer.CreatedDate.ToString("dd-MM-yyyy")
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest();

            CustomersComment dbCustomer = await _context.CustomersComments.FirstOrDefaultAsync(m => m.Id == id);

            //if (dbIcon is null) return NotFound();

            dbCustomer.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }
    }
}

