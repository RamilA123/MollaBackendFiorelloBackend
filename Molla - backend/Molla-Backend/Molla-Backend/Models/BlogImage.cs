using System;
namespace Molla_Backend.Models
{
	public class BlogImage:BaseEntity
	{
		public string Image { get; set; }
		public bool IsMain { get; set; }
		public int BlogId { get; set; }
		public Blog Blog { get; set; }
        public bool Status { get; set; } = true;
    }
}

