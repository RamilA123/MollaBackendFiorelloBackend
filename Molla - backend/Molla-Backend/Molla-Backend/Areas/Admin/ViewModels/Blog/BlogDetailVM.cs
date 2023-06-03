using System;
namespace Molla_Backend.Areas.Admin.ViewModels.Blog
{
	public class BlogDetailVM
	{
        public string Image { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public string CreateDate { get; set; }
    }
}

