using System;
using Molla_Backend.Models;

namespace Molla_Backend.Areas.Admin.ViewModels.Blog
{
	public class BlogVM
	{
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public string CreateDate { get; set; }
    }
}

