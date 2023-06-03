using System;
namespace Molla_Backend.Areas.Admin.ViewModels.Icon
{
	public class IconVM
	{
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public bool Status { get; set; }
        public string CreateDate { get; set; }
    }
}

