using System;
namespace Molla_Backend.Models
{
	public class TeamMembersImage:BaseEntity
	{
		public string Image { get; set; }
		public bool IsMain { get; set; }
		public int TeamMembersId { get; set; }
		public TeamMembers TeamMembers { get; set; }
	}
}

