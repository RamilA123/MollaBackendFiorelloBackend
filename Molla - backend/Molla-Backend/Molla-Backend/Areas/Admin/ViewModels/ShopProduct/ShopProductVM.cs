using System;
namespace Molla_Backend.Areas.Admin.ViewModels.ShopProduct
{
	public class ShopProductVM
	{
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Features { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int SalesCount { get; set; }
        public bool Status { get; set; }
        public string CreateDate { get; set; }
    }
}

