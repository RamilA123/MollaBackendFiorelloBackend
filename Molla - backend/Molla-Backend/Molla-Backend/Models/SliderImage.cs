using System;
namespace Molla_Backend.Models
{
	public class SliderImage:BaseEntity
	{
		public string Image { get; set; }
		public bool IsMain { get; set; }
		public int SliderId { get; set; }
		public Slider Slider { get; set; }
	}
}

