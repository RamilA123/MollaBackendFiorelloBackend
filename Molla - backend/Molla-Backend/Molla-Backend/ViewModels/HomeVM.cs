using System;
using Molla_Backend.Models;

namespace Molla_Backend.ViewModels
{
	public class HomeVM
	{
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<BrandsImage> BrandsImages { get; set; }
        public IEnumerable<Icons> Icons { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

