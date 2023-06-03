using System;
namespace Molla_Backend.Models
{
	public class TeamMembers:BaseEntity
	{
		public string FullName { get; set; }
		public string Position { get; set; }
		public string Info { get; set; }
		public ICollection<TeamMembersImage> Images { get; set; }
        public bool Status { get; set; } = false;
    }
}

