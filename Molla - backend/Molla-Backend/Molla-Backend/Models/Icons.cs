using System;
namespace Molla_Backend.Models
{
	public class Icons:BaseEntity
	{
		public string ClassName { get; set; }
		public string Title { get; set; }
		public string Info { get; set; }
        public bool Status { get; set; } = true;
    }
}

