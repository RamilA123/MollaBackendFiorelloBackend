using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_Backend.Areas.Admin.ViewModels.BrandsImage;
using Molla_Backend.Areas.Admin.ViewModels.ShopProduct;
using Molla_Backend.Areas.Admin.ViewModels.TeamMember;
using Molla_Backend.Data;
using Molla_Backend.Models;
using Molla_Backend.Services.Interfaces;

namespace Molla_Backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILayoutService _layoutService;

        public TeamMemberController(AppDbContext context, ILayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index()
        {
            List<TeamMemberVM> teamMemberList = new();
            List<TeamMembers> teamMembers = await _context.TeamMembers.Include(m => m.Images).Where(m => !m.SoftDelete).ToListAsync();

            foreach (TeamMembers eachMember in teamMembers)
            {
                TeamMemberVM model = new()
                {
                    Id = eachMember.Id,
                    Image = eachMember.Images.FirstOrDefault().Image,
                    FullName = eachMember.FullName,
                    Position = eachMember.Position,
                    Status = eachMember.Status,
                    CreateDate = eachMember.CreatedDate.ToString("dd-MM-yyyy")
                };

                teamMemberList.Add(model);
            }
            return View(teamMemberList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            //if (id is null) return BadRequest();

            TeamMembers dbMember = await _context.TeamMembers.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);

            //if (dbBlog is null) return NotFound();

            TeamMemberDetailVM model = new()
            {
                Image = dbMember.Images.FirstOrDefault().Image,
                FullName = dbMember.FullName,
                Info = dbMember.Info,
                Position = dbMember.Position,
                Status = dbMember.Status,
                CreateDate = dbMember.CreatedDate.ToString("dd-MM-yyyy")
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //if (id is null) return BadRequest();

            TeamMembers dbMember = await _context.TeamMembers.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);

            //if (dbIcon is null) return NotFound();

            dbMember.SoftDelete = true;
            _layoutService.SaveAction();
            return RedirectToAction("Index");
        }
    }
}

