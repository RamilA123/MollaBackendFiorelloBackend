using System;
namespace Molla_Backend.Models
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public bool SoftDelete { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}

