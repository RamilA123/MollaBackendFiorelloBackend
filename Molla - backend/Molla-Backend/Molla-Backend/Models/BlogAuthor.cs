using System;
namespace Molla_Backend.Models
{
	public class BlogAuthor:BaseEntity
	{
		public string FullName { get; set; }
		public ICollection<Blog> Blogs { get; set; }
	}
}

