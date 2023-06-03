using System;
namespace Molla_Backend.Areas.Admin.ViewModels.BrandsInfo
{
	public class BrandsInfoVM
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CreateDate { get; set; }
    }
}

