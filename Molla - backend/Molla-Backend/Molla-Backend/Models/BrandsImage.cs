using System;
namespace Molla_Backend.Models
{
	public class BrandsImage:BaseEntity
	{
        public string Image { get; set; }
        public bool Status { get; set; } = true;
    }
}

