using System;
namespace Molla_Backend.Models
{
	public class Slider:BaseEntity
	{
		public string Title { get; set; }
		public string Info { get; set; }
		public decimal DiscountedPrice { get; set; }
		public decimal ActualPrice { get; set; }
		public ICollection<SliderImage> SliderImages { get; set; }
	}
}

