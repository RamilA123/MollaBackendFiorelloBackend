using System;
namespace Molla_Backend.Models
{
	public class BrandsInfo:BaseEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = true;
    }
}

