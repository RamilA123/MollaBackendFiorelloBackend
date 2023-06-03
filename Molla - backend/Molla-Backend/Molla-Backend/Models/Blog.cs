using System;
namespace Molla_Backend.Models
{
	public class Blog:BaseEntity
	{
		public string Title { get; set; }
		public string Info { get; set; }
		public string MainDescription { get; set; }
		public int BlogAuthorId { get; set; }
		public BlogAuthor BlogAuthor { get; set; }
		public ICollection<BlogImage> Images { get; set; }
        public bool Status { get; set; } = true;
    }
}

