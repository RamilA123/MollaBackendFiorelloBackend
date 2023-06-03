using System;
namespace Molla_Backend.Models
{
	public class Product:BaseEntity
	{
        public string Features { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public int SalesCount { get; set; }
        public bool Status { get; set; } = false;
    }
}

