using System;
namespace Molla_Backend.Models
{
	public class CustomersComment : BaseEntity
	{
		public string Image { get; set; }
		public string Description { get; set; }
		public string FullName { get; set; }
		public string Position { get; set; }
        public bool Status { get; set; } = true;
    }
}

