using System;
namespace Molla_Backend.Models
{
	public class WhoWeAreInfo:BaseEntity
	{
		public string Title { get; set; }
		public string Info { get; set; }
		public string MainDescription { get; set; }
        public bool Status { get; set; } = true;
    }
}

