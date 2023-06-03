using System;
using Molla_Backend.Models;
using Molla_Backend.Data;
using Molla_Backend.ViewModels;
using Molla_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Molla_Backend.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, string> GetAllDatas()
        {
            var datas = _context.Settings.AsEnumerable().ToDictionary(m => m.Key, m => m.Value);

            return datas;
        }

        public void SaveAction()
        {
            _context.SaveChangesAsync();
        }
    }
}

